namespace Byteology.Website.Components;

using Byteology.Website.Components.Input;

public partial class TabbedWindow<TItem> : ByteologyComponent
{
    private int _selectedIndex = 0;

    [Parameter, Required]
    public IReadOnlyList<TItem> Items { get; set; } = default!;

    [Parameter, Required]
    public RenderFragment<RadioButtonsList<TItem>.Context> TabContent { get; set; } = default!;

    [Parameter, Required]
    public RenderFragment<TItem> Body { get; set; } = default!;

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
