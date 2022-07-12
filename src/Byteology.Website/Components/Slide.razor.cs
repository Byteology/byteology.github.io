namespace Byteology.Website.Components;

public partial class Slide
{
    [Parameter]
    public Theme Theme { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; } = default!;
}
