namespace Byteology.Website.Components;

using Microsoft.JSInterop;

public partial class PageRoot : IDisposable
{
    private bool _initialFullPageScrollingValue;

    [Inject]
    private IJSRuntime _jsRuntimeAsync { get; set; } = default!;
    private IJSInProcessRuntime _jsRuntime => (IJSInProcessRuntime)_jsRuntimeAsync;

    [Parameter]
    public bool FullPageScrolling { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        if (FullPageScrolling != _initialFullPageScrollingValue)
            throw new InvalidOperationException($"The value of the parameter {nameof(FullPageScrolling)} can't be changed.");
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        _initialFullPageScrollingValue = FullPageScrolling;
    }

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);

        if (firstRender && FullPageScrolling)
            _jsRuntime.InvokeVoid("fps.init");
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing && FullPageScrolling)
            _jsRuntime.InvokeVoid("fps.dispose");
    }
}
