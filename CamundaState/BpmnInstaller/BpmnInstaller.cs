using Camunda.Worker;
using Camunda.Worker.Client;
using CamundaState.BpmnServices;

namespace CamundaState.BpmnInstaller
{
    public static class BpmnInstaller
    {
	    public static IServiceCollection AddCamunda(this IServiceCollection services, string camundaRestApiUri, string? camundaRestAuthorization)
	    {
		    services.AddSingleton(_ => new BpmnService(camundaRestApiUri, camundaRestAuthorization));
		    services.AddHostedService<BpmnProcessDeployService>();

		    services.AddExternalTaskClient(client =>
		    {
			    client.BaseAddress = new Uri(camundaRestApiUri);
		    });

		    services.AddCamundaWorker("projectWorker");

		    return services;
	    }
    }
}
