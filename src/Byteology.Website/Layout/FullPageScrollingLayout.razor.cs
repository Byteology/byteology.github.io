namespace Byteology.Website.Layout;

using Microsoft.JSInterop;

public partial class FullPageScrollingLayout : LayoutComponentBase, IDisposable
{
    private string? _fadeInAnimationClass;

    [Inject]
    private LayoutStateContainer _state { get; set; } = default!;

    [Inject]
    private IJSRuntime _jsRuntimeAsync { get; set; } = default!;
    private IJSInProcessRuntime _jsRuntime => (IJSInProcessRuntime)_jsRuntimeAsync;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (!_state.Prerendering)
            _fadeInAnimationClass = "fade-in";
    }
    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);

        _jsRuntime.InvokeVoid("onNavigated");

        if (firstRender)
            _jsRuntime.InvokeVoid("fps.start");

        bool shouldRerender = _state.Prerendering;
        _state.OnLayoutChanged(false);

        if (shouldRerender)
            StateHasChanged();
        else
        {
            _fadeInAnimationClass = _fadeInAnimationClass switch
            {
                "fade-in" => "fade-in-alt",
                "fade-in-alt" => "fade-in",
                _ => "fade-in"
            };
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
            _jsRuntime.InvokeVoid("fps.stop");
    }
}
