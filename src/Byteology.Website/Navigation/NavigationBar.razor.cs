namespace Byteology.Website.Navigation;

using Microsoft.JSInterop;

public partial class NavigationBar : ComponentBase
{
	[Inject]
	private IJSRuntime _jsRuntimeAsync { get; set; } = default!;
	private IJSInProcessRuntime _jsRuntime => (IJSInProcessRuntime)_jsRuntimeAsync;

	private void onClickOutside()
	{
		_jsRuntime.InvokeVoid("collapseHamburger");
	}

	private double _touchStartX;
	private bool _touchIgnored;
	private void onTouchStart(TouchEventArgs args)
	{
		_touchStartX = args.Touches[0].ClientX;
		_touchIgnored = args.Touches.Length != 1;
	}

	private void onTouchMove(TouchEventArgs args)
	{
		if (!_touchIgnored)
		{
			if (_touchStartX > args.Touches[0].ClientX)
				_jsRuntime.InvokeVoid("collapseHamburger");
			else
				_touchIgnored = true;
		}
	}
}
