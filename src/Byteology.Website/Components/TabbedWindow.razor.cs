namespace Byteology.Website.Components;

public partial class TabbedWindow<TItem> : ComponentBase
{
    private int _selectedIndex = 0;

    [CascadingParameter]
    public Theme Theme { get; set; }

    [Parameter]
    public IReadOnlyList<TItem> Items { get; set; } = default!;

    [Parameter]
    public RenderFragment<RadioButtonsList<TItem>.Context> TabContent { get; set; } = default!;

    [Parameter]
    public RenderFragment<TItem> Body { get; set; } = default!;

    [Parameter]
    public string? Class { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? InputAttributes { get; set; }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (Items == null || Items.Count == 0)
            throw new ArgumentException("There should be at least one item.");

        if (TabContent == null)
            throw new ArgumentNullException(nameof(TabContent));

        if (Body == null)
            throw new ArgumentNullException(nameof(Body));
    }

    private void onChanged(RadioButtonsList<TItem>.RadioButtonEventArgs args)
    {
        _selectedIndex = args.Index;
    }
}
