using CamundaState.AppContext;
using Action = CamundaState.Models.Action;

namespace CamundaState.Repo;

public class ActionRepository
: IBaseRepository<Action>
	{
	private readonly WorkflowContext _dbContext;
	public ActionRepository(WorkflowContext dbContext)
	{
		_dbContext = dbContext;
	}
	public async Task<Action> Create(Action entity)
	{
		await _dbContext.Actions.AddAsync(entity);
		await _dbContext.SaveChangesAsync();
		return entity;
	}

	public async Task<Action> Delete(Action entity)
	{
		_dbContext.Remove(entity);
		await _dbContext.SaveChangesAsync();
		return entity;
	}

	public async Task<IQueryable<Action>> Get()
	{
		return _dbContext.Actions;
	}

	public async Task<Action> Update(Action entity)
	{
		_dbContext.Actions.Update(entity);
		await _dbContext.SaveChangesAsync();
		return entity;
	}
}