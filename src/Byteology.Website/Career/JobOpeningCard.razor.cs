namespace Byteology.Website.Career;

public partial class JobOpeningCard : ComponentBase
{
	[Parameter, EditorRequired]
	public JobOpening Opening { get; set; } = default!;
}
