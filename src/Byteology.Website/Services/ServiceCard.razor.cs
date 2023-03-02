namespace Byteology.Website.Services;

public partial class ServiceCard : ComponentBase
{
	[Parameter, EditorRequired]
	public Type Icon { get; set; } = default!;

	[Parameter, EditorRequired]
	public string Title { get; set; } = default!;

	[Parameter, EditorRequired]
	public string Description { get; set; } = default!;

	[Parameter, EditorRequired]
	public Type PageLink { get; set; } = default!;
}
