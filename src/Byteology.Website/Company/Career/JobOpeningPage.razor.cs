namespace Byteology.Website.Company.Career;

public partial class JobOpeningPage
{
	[Parameter]
	public string OpeningId { get; set; } = default!;

	private Type? _component;

	protected override void OnParametersSet()
	{
		base.OnParametersSet();

		_component = JobOpenings.Current.FirstOrDefault(x => x.Id == OpeningId)?.DetailsComponent;
	}
}
