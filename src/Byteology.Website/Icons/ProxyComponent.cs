namespace Byteology.Website.Icons;

using Microsoft.AspNetCore.Components.Rendering;

public class ProxyComponent : ComponentBase
{
    [Parameter]
    [EditorRequired]
    public Type ComponentToRender { get; set; } = default!;

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenComponent(1, ComponentToRender);
        builder.AddMultipleAttributes(2, AdditionalAttributes);
        builder.CloseComponent();
    }
}
