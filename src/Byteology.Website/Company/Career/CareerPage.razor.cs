namespace Byteology.Website.Company;

public partial class CareerPage : ComponentBase
{
	[Parameter]
	[SupplyParameterFromQuery(Name = "opening")]
	public string? OpeningId { get; set; }
}
