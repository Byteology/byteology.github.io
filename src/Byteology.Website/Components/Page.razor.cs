namespace Byteology.Website.Components;

using Microsoft.JSInterop;

public partial class Page : ComponentBase, IDisposable
{
    [Inject]
    private StateContainer _state { get; set; } = default!; 

    [Inject]
    private IJSRuntime _jsRuntimeAsync { get; set; } = default!;
    private IJSInProcessRuntime _jsRuntime => (IJSInProcessRuntime)_jsRuntimeAsync;

    [Parameter]
    public bool FullPageScrolling { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);

        if (firstRender)
        {
            _state.InitialLoad = false;
            if (FullPageScrolling)
                _jsRuntime.InvokeVoid("fps.start");
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing && FullPageScrolling)
            _jsRuntime.InvokeVoid("fps.stop");
    }
}