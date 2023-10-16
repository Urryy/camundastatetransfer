using CamundaState.BpmnServices;
using CamundaState.Models.dto;
using CamundaState.Models;
using CamundaState.Repo;
using System.Transactions;
using Microsoft.EntityFrameworkCore;

namespace CamundaState.Services;

public class CamundaTranslateService : ICamundaTranslateService
{
    private static ExecuteState? executeState;

    private readonly IBaseRepository<ProjectWf> _projectRepository;
    private readonly BpmnService _bpmnService;

    private delegate Task<bool> ExecuteState(IEnumerable<ProjectWf> projects);

    public CamundaTranslateService(IBaseRepository<ProjectWf> projectRepository, BpmnService bpmnService)
    {
        _projectRepository = projectRepository;
        _bpmnService = bpmnService;
    }

    public async Task<BaseResponseDto<IEnumerable<ProjectWf>>> CheckIsTranslate()
    {
        try
        {   //Ideally, use AsNoTracking(), but since we have a binding object in the form of  -->Status<-- ,
            // we cannot use this method
            // (await _projectRepository.Get()).AsNoTracking()  !!!

            var projects = await _projectRepository.Get();
            if (projects.Count() == 0)
                return new BaseResponseDto<IEnumerable<ProjectWf>>
                { data = null, status = false, message = "failed" };

            var newquery = await projects.ToListAsync();

            executeState = Execute;

            return new BaseResponseDto<IEnumerable<ProjectWf>>
            { data = newquery, status = true, message = "success" };
        }
        catch (Exception e)
        {
            return new BaseResponseDto<IEnumerable<ProjectWf>>
            { data = null, status = false, message = "failed" };
        }
    }

    public async Task<bool> InvokeTask(IEnumerable<ProjectWf> projects)
    {
        if (executeState == null)
            return default;

        return await executeState(projects);
    }

    private async Task<bool> Execute(IEnumerable<ProjectWf> projects)
    {
        foreach (var project in projects)
        {
            try
            {
                if (project.Status.Name.Contains("Completed"))
                    continue;

                using var tx = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

                var processInstanceId = await _bpmnService.StartProcessFor(project);
                project.AssociateWithProcessInstance(processInstanceId);

                await _projectRepository.Update(project);
                tx.Complete();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new NullReferenceException(e.Message);
            }
        }
        return true;
    }
}