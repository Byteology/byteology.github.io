namespace Byteology.Website.Career;

public partial class JobOpeningPage : ComponentBase
{
	[Parameter]
	public string OpeningId { get; set; } = default!;

	[Inject]
	private JobOpeningsRepository _repository { get; set; } = default!;
}
