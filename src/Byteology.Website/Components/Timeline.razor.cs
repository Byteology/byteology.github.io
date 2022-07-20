﻿namespace Byteology.Website.Components;

public partial class Timeline
{
    [CascadingParameter]
    public Theme Theme { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? InputAttributes { get; set; }

    [Parameter]
    public MarkupString[] Items { get; set; } = default!;
}
