namespace Byteology.Website.Services;

public partial class ServicesList : ComponentBase
{
	[Inject]
	private ServicesInfoRepository _servicesInfoRepository { get; set; } = default!;
}