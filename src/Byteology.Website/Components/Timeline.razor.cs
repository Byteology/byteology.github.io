namespace Byteology.Website.Components;

public partial class Timeline
{
    [CascadingParameter(Name = "Dark")]
    public bool Dark { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? InputAttributes { get; set; }

    private readonly List<MarkupString> _items = new();

    public MarkupString this[int index] 
    {
        get => _items[index];
        set
        {
            _items[index] = value;
            StateHasChanged();
        }
    }

    public int Count => _items.Count;

    public void Add(MarkupString item)
    {
        _items.Add(item);
        StateHasChanged();
    }

    public void Clear()
    {
        _items.Clear();
        StateHasChanged();
    }

    public void Insert(int index, MarkupString item)
    {
        _items.Insert(index, item);
        StateHasChanged();
    }

    public bool Remove(MarkupString item)
    {
        bool success = _items.Remove(item);
        StateHasChanged();
        return success;
    }

    public void RemoveAt(int index)
    {
        _items.RemoveAt(index);
        StateHasChanged();
    }
}
