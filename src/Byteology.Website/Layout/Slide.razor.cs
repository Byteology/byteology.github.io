namespace Byteology.Website.Layout;

public partial class Slide : ComponentBase
{
	[Inject]
	private LayoutStateContainer _state { get; set; } = default!;

	[Parameter]
	public bool IncludeFooter { get; set; }

	[Parameter]
	public RenderFragment? ChildContent { get; set; }
}
