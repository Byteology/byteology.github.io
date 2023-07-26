namespace Byteology.Website.Shared;

public partial class Metadata : ComponentBase
{
	[Parameter, EditorRequired]
	public string Title { get; set; } = default!;

	[Parameter]
	public string? Description { get; set; }

	[Parameter]
	public string[]? Keywords { get; set; }

	[Parameter]
	public bool Article { get; set; }
}
