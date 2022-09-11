namespace Byteology.Website.Layouts;

using Microsoft.JSInterop;

public abstract class LayoutBase : LayoutComponentBase
{
    [Inject]
    private IJSRuntime _jsRuntimeAsync { get; set; } = default!;
    private IJSInProcessRuntime _jsRuntime => (IJSInProcessRuntime)_jsRuntimeAsync;

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);
        _jsRuntime.InvokeVoid("onNavigated");
    }
}
