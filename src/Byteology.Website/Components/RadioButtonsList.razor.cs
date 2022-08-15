namespace Byteology.Website.Components;

public partial class RadioButtonsList<TItem> : ComponentBase
{
    private int _selectedItemIndex;

    [Parameter]
    public IReadOnlyList<TItem> Items { get; set; } = default!;

    [Parameter]
    public RenderFragment<Context> ItemTemplate { get; set; } = default!;

    [Parameter]
    public EventCallback<RadioButtonEventArgs> OnChanged { get; set; }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (Items == null || Items.Count == 0)
            throw new ArgumentException("There should be at least one item.");

        if (ItemTemplate == null)
            throw new ArgumentNullException(nameof(ItemTemplate));
    }

    private async Task onClicked(int itemIndex)
    {
        int oldIndex = _selectedItemIndex;

        _selectedItemIndex = itemIndex;

        if (oldIndex != _selectedItemIndex)
            await OnChanged.InvokeAsync(new RadioButtonEventArgs(Items[_selectedItemIndex], _selectedItemIndex));
    }

    private async Task onKeyPressed(KeyboardEventArgs args, int itemIndex)
    {
        int oldIndex = _selectedItemIndex;

        if (args.Code == "Enter" || args.Code == "NumpadEnter" || args.Code == "Space")
            _selectedItemIndex = itemIndex;

        if (oldIndex != _selectedItemIndex)
            await OnChanged.InvokeAsync(new RadioButtonEventArgs(Items[_selectedItemIndex], _selectedItemIndex));
    }

    public class Context
    {
        public TItem Value { get; set; }
        public bool Selected { get; set; }

        public Context(TItem value, bool selected)
        {
            Value = value;
            Selected = selected;
        }
    }

    public class RadioButtonEventArgs : EventArgs
    {
        public TItem SelectedItem { get; }
        public int Index { get; }

        public RadioButtonEventArgs(TItem selectedItem, int index)
        {
            SelectedItem = selectedItem;
            Index = index;
        }
    }
}
