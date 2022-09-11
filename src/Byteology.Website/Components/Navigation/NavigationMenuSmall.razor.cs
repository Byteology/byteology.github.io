namespace Byteology.Website.Components.Navigation;

using Microsoft.JSInterop;

public partial class NavigationMenuSmall
{
    private readonly NavigationData _data = new();

    [Inject]
    private IJSRuntime _jsRuntimeAsync { get; set; } = default!;
    private IJSInProcessRuntime _jsRuntime => (IJSInProcessRuntime)_jsRuntimeAsync;

    private void onClickOutside()
    {
        _jsRuntime.InvokeVoid("collapseHamburder");
    }

    private double _touchStartX;
    private void onTouchStart(TouchEventArgs args)
    {
        _touchStartX = args.Touches.First().ClientX;
    }
    private void onTouchMove(TouchEventArgs args)
    {
        if (_touchStartX > args.Touches.First().ClientX)
            _jsRuntime.InvokeVoid("collapseHamburder");
    }
}
