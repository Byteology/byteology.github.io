namespace Byteology.Website.Components;

public partial class TabbedWindow<TItem> : ComponentBase
{
    private int _selectedTabIndex;

    [CascadingParameter]
    public Theme Theme { get; set; }

    [Parameter]
    public IReadOnlyList<TItem> Items { get; set; } = default!;

    [Parameter]
    public RenderFragment<Context> TabContent { get; set; } = default!;

    [Parameter]
    public RenderFragment<Context> Body { get; set; } = default!;

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

    private void onClicked(int tabIndex)
    {
        _selectedTabIndex = tabIndex;
    }

    private void onKeyPressed(KeyboardEventArgs args, int tabIndex)
    {
        if (args.Code == "Enter" || args.Code == "NumpadEnter")
            _selectedTabIndex = tabIndex;
    }

    public class Context
    {
        public TItem Item { get; set; }
        public bool Selected { get; set; }

        public Context(TItem item, bool selected)
        {
            Item = item;
            Selected = selected;
        }
    }
}
