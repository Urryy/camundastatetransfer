using CamundaState.AppContext;
using CamundaState.Models;

namespace CamundaState.Repo;

public class ProjectWfRepository : IBaseRepository<ProjectWf>
{
	private readonly WorkflowContext _dbContext;
	public ProjectWfRepository(WorkflowContext dbContext)
	{
		_dbContext = dbContext;
	}
	public async Task<ProjectWf> Create(ProjectWf entity)
	{
		await _dbContext.ProjectWfs.AddAsync(entity);
		await _dbContext.SaveChangesAsync();
		return entity;
	}

	public async Task<ProjectWf> Delete(ProjectWf entity)
	{
		_dbContext.ProjectWfs.Remove(entity);
		await _dbContext.SaveChangesAsync();
		return entity;
	}

	public async Task<IQueryable<ProjectWf>> Get()
	{
		return _dbContext.ProjectWfs;
	}

	public async Task<ProjectWf> Update(ProjectWf entity)
	{
		_dbContext.ProjectWfs.Update(entity);
		await _dbContext.SaveChangesAsync();
		return entity;
	}
}