namespace Byteology.Website.Career;

public partial class CareerPage : ComponentBase
{
	[Parameter]
	[SupplyParameterFromQuery(Name = "opening")]
	public string? OpeningId { get; set; }
}
