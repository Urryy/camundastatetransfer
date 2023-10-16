using CamundaState.AppContext;
using CamundaState.Models;

namespace CamundaState.Repo;

public class StatusRepository : IBaseRepository<Status>
{
	private readonly WorkflowContext _dbContext;
	public StatusRepository(WorkflowContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<Status> Create(Status entity)
	{
		await _dbContext.Statuses.AddAsync(entity);
		await _dbContext.SaveChangesAsync();
		return entity;
	}

	public async Task<Status> Delete(Status entity)
	{
		_dbContext.Statuses.Remove(entity);
		await _dbContext.SaveChangesAsync();
		return entity;
	}

	public async Task<IQueryable<Status>> Get()
	{
		return _dbContext.Statuses;
	}

	public async Task<Status> Update(Status entity)
	{
		_dbContext.Statuses.Update(entity);
		await _dbContext.SaveChangesAsync();
		return entity;
	}
}