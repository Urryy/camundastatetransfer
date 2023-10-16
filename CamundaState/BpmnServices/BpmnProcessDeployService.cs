using Microsoft.Extensions.Options;

namespace CamundaState.BpmnServices
{
    public class BpmnProcessDeployService
	    : IHostedService
    {
	    private readonly BpmnService _bpmnService;
	    private readonly IOptions<AppSettings> _options;

	    public BpmnProcessDeployService(BpmnService bpmnService, IOptions<AppSettings> options)
	    {
		    _bpmnService = bpmnService;
		    _options = options;
	    }

	    public async Task StartAsync(CancellationToken cancellationToken)
	    {
		    await _bpmnService.DeployProcessDefinition(_options.Value);
	    }

	    public Task StopAsync(CancellationToken cancellationToken)
		    => Task.CompletedTask;
    }
}
