namespace Byteology.Website.Components;

using Byteology.Website.Theming;

public partial class LinkButton
{
    [CascadingParameter(Name = "Theme")]
    public Theme Theme { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? InputAttributes { get; set; }

    [Parameter]
    public string? Text { get; set; }

    [Parameter]
    public string? Url { get; set; }
}
