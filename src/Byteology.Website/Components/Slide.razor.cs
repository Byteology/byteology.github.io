namespace Byteology.Website.Components;

public partial class Slide
{
    [Parameter]
    public RenderFragment ChildContent { get; set; } = default!;
}
