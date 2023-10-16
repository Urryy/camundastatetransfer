namespace CamundaState.Repo;

public interface IBaseRepository<T> where T : class
{
	Task<IQueryable<T>> Get();
	Task<T> Update(T entity);
	Task<T> Delete(T entity);
	Task<T> Create(T entity);
}