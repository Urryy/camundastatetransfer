using CamundaState.AppContext;

namespace CamundaState.Init
{
    public class DbSeed
    {
	    private readonly WorkflowContext _db;

	    public DbSeed(WorkflowContext db)
	    {
		    _db = db;
	    }

#pragma warning disable CS1998 // В асинхронном методе отсутствуют операторы await, будет выполнен синхронный метод
	    public async Task SeedData()
#pragma warning restore CS1998 // В асинхронном методе отсутствуют операторы await, будет выполнен синхронный метод
	    {

	    }
    }
}
