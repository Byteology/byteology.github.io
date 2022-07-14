namespace Byteology.Website.Components;

public partial class LinkButton
{
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? InputAttributes { get; set; }

    [Parameter]
    public string? Text { get; set; }

    [Parameter]
    public string? Url { get; set; }
}
