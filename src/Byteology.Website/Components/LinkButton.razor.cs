namespace Byteology.Website.Components;

public partial class LinkButton
{
    [CascadingParameter]
    public Theme Theme { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? InputAttributes { get; set; }

    [Parameter]
    public bool Primary { get; set; }

    [Parameter]
    public string? Text { get; set; }

    [Parameter]
    public string? Url { get; set; }
}
