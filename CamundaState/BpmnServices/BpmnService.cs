using Camunda.Api.Client;
using Camunda.Api.Client.Deployment;
using Camunda.Api.Client.ProcessDefinition;
using Camunda.Api.Client.UserTask;
using CamundaState.Models;

namespace CamundaState.BpmnServices
{
    public class BpmnService
    {
        private readonly CamundaClient _camunda;

        public BpmnService(string camundaRestApiUri, string? camundaRestAuthorization)
        {
            if (string.IsNullOrWhiteSpace(camundaRestAuthorization))
            {
                _camunda = CamundaClient.Create(camundaRestApiUri);
            }
            else
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(camundaRestApiUri);
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {camundaRestAuthorization}");
                _camunda = CamundaClient.Create(httpClient);
            }
        }

        public async Task DeployProcessDefinition(AppSettings settings)
        {
            var bpmnResourceStream = this.GetType().Assembly.GetManifestResourceStream(settings.CamundaFilePath);

            try
            {
                await _camunda.Deployments.Create(
                    settings.CamundaDeploymentName,
                    true,
                    true,
                    null,
                    null,
                    new ResourceDataContent(bpmnResourceStream, settings.CamundaFileName));
            }
            catch (Exception e)
            {
                throw new ApplicationException("Failed to deploy process definition", e);
            }
        }

        public async Task<string> StartProcessFor(ProjectWf projectWf)
        {
            var processParams = new StartProcessInstance()
                .SetVariable("objectWfId", VariableValue.FromObject(projectWf.Id.ToString()))
                .SetVariable("objectId", VariableValue.FromObject(projectWf.ObjectId.ToString()))
                .SetVariable("objectName", VariableValue.FromObject(projectWf.ObjectName))
                .SetVariable("objectStatus", VariableValue.FromObject(projectWf!.Status!.Name))
                .SetVariable("categoryProject", VariableValue.FromObject(projectWf.CategoryId.ToString()))
                .SetVariable("typeProject", VariableValue.FromObject(projectWf.TypeId.ToString()));

            processParams.BusinessKey = projectWf.Id.ToString();

            var processStartResult = await
                _camunda.ProcessDefinitions.ByKey("Process_Project").StartProcessInstance(processParams);

            return processStartResult.Id;
        }

        public async Task<List<UserTaskInfo>> GetTasksForCandidateGroup(string group, string user)
        {
            var groupTaskQuery = new TaskQuery
            {
                ProcessDefinitionKeys = { "Process_Project" },
                //CandidateGroup = group
            };
            var groupTasks = await _camunda.UserTasks.Query(groupTaskQuery).List();

            return groupTasks;
        }

        public async Task<UserTaskInfo> CompleteTask(string taskId, ProjectWf projectWf)
        {
            try
            {
                var task = await _camunda.UserTasks[taskId].Get();
                var completeTask = new CompleteTask()
                    .SetVariable("objectStatus", VariableValue.FromObject(projectWf.Status.Name));

                await _camunda.UserTasks[taskId].Complete(completeTask);
                return task;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
