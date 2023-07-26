namespace Byteology.Website.Company.People;

public partial class PersonIntro : ComponentBase
{
	[Parameter, EditorRequired]
	public string Name { get; set; } = default!;

	[Parameter, EditorRequired]
	public string Title { get; set; } = default!;

	[Parameter, EditorRequired]
	public string ImageSrc { get; set; } = default!;

	[Parameter]
	public RenderFragment? ChildContent { get; set; }
}
