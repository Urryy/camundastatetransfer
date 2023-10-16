namespace CamundaState.Init
{
    public class DbInitializer
	    : IHostedService
    {
	    private readonly IServiceProvider _serviceProvider;

	    public DbInitializer(IServiceProvider serviceProvider)
	    {
		    _serviceProvider = serviceProvider;
	    }

	    public async Task StartAsync(CancellationToken cancellationToken)
	    {
		    using var scope = _serviceProvider.CreateScope();
		    await scope.ServiceProvider.GetService<DbSeed>()!.SeedData();
	    }

	    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
