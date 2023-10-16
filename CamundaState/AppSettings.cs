namespace CamundaState;

public class AppSettings
{
	public string? Secret { get; set; }
	public string[]? AllowedOrigins { get; set; }
	public string? CamundaRestAuthorization { get; set; }
	public string CamundaRestApiUri { get; set; } = default!;
	public string CamundaDeploymentName { get; set; } = default!;
	public string CamundaFilePath { get; set; } = default!;
	public string CamundaFileName { get; set; } = default!;
}