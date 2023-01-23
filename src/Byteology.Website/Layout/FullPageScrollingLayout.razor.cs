namespace Byteology.Website.Layout;

using Microsoft.JSInterop;

public partial class FullPageScrollingLayout : LayoutComponentBase, IDisposable
{
    private bool _fadeIn;
    private bool _altFadeInAnimation;

    [Inject]
    private LayoutStateContainer _state { get; set; } = default!;

    [Inject]
    private IJSRuntime _jsRuntimeAsync { get; set; } = default!;
    private IJSInProcessRuntime _jsRuntime => (IJSInProcessRuntime)_jsRuntimeAsync;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        _state.InitialRender = _state.InitialRender == null;
        _fadeIn = !_state.InitialRender.Value;
        _state.FullPageScrolling = true;
    }

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);

        _jsRuntime.InvokeVoid("onNavigated");

        if (firstRender)
            _jsRuntime.InvokeVoid("fps.start");

        if (_state.InitialRender == true)
        {
            _state.InitialRender = false;
            StateHasChanged();
        }
        else
        {
            _fadeIn = true;
            _altFadeInAnimation = !_altFadeInAnimation;
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
