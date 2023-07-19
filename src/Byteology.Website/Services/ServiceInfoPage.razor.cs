namespace Byteology.Website.Services;

public partial class ServiceInfoPage : ComponentBase
{
	[Parameter]
	public string Handle { get; set; } = default!;

	[Inject]
	private ServicesInfoRepository _serviceInfoRepository { get; set; } = default!;
}
