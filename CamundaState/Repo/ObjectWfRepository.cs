using CamundaState.AppContext;
using CamundaState.Models;

namespace CamundaState.Repo;

public class ObjectWfRepository : IBaseRepository<ObjectWf>
{
	private readonly WorkflowContext _dbContext;
	public ObjectWfRepository(WorkflowContext dbContext)
	{
		_dbContext = dbContext;
	}
	public async Task<IQueryable<ObjectWf>> Get()
	{
		return _dbContext.ObjectWfs;
	}

	public async Task<ObjectWf> Update(ObjectWf entity)
	{
		_dbContext.ObjectWfs.Update(entity);
		await _dbContext.SaveChangesAsync();
		return entity;
	}

	public async Task<ObjectWf> Delete(ObjectWf entity)
	{
		_dbContext.ObjectWfs.Remove(entity);
		await _dbContext.SaveChangesAsync();
		return entity;
	}

	public async Task<ObjectWf> Create(ObjectWf entity)
	{
		await _dbContext.ObjectWfs.AddAsync(entity);
		await _dbContext.SaveChangesAsync();
		return entity;
	}
}