namespace Byteology.Website.Layout;

using Microsoft.JSInterop;

public partial class BasicLayout : LayoutComponentBase
{
	private bool _comesFromFullPageScrolling;
	private bool _fadeIn;
	private bool _altFadeInAnimation;

	[Inject]
	private LayoutStateContainer _state { get; set; } = default!;

	[Inject]
	private IJSRuntime _jsRuntimeAsync { get; set; } = default!;
	private IJSInProcessRuntime _jsRuntime => (IJSInProcessRuntime)_jsRuntimeAsync;

	protected override void OnParametersSet()
	{
		base.OnParametersSet();
		_comesFromFullPageScrolling = false;
	}

	protected override void OnInitialized()
	{
		base.OnInitialized();
		_state.InitialRender = _state.InitialRender == null;
		_fadeIn = !_state.InitialRender.Value;
		_comesFromFullPageScrolling = _state.FullPageScrolling;
		_state.FullPageScrolling = false;
	}

	protected override void OnAfterRender(bool firstRender)
	{
		base.OnAfterRender(firstRender);

		_jsRuntime.InvokeVoid("onNavigated");

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
}
