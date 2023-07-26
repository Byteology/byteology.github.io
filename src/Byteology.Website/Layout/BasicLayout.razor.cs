namespace Byteology.Website.Layout;

using Microsoft.JSInterop;

public partial class BasicLayout : LayoutComponentBase
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

		bool shouldRerender = _state.Prerendering;
		_state.OnLayoutChanged(true);

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
}
