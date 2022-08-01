namespace Byteology.Website.Components;

using Microsoft.JSInterop;

public partial class VisualViewport : ComponentBase, IAsyncDisposable
{
    [Inject]
    private IJSRuntime _jsRuntime { get; set; } = default!;
    private IJSObjectReference? _module { get; set; }
    private DotNetObjectReference<VisualViewport> _dotNetObjectReference = default!;

    public double Top { get; private set; }
    public double Left { get; private set; }
    public double Width { get; private set; }
    public double Height { get; private set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; } = default!;

    public ElementReference DomReference { get; private set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        _dotNetObjectReference = DotNetObjectReference.Create(this);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _module = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "./js/visual-viewport.js");
            await _module.InvokeVoidAsync("init", _dotNetObjectReference);
        }
    }

    [JSInvokable("onChanged")]
    public void OnChanged(double top, double left, double width, double height)
    {
        Top = top;
        Left = left;
        Width = width;
        Height = height;
        StateHasChanged();
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore();
        GC.SuppressFinalize(this);
    }

    protected virtual async ValueTask DisposeAsyncCore()
    {
        if (_module != null)
            await _module.InvokeVoidAsync("dispose");
    }
}
