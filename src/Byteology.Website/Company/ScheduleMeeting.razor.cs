namespace Byteology.Website.Company;

using Microsoft.JSInterop;

public partial class ScheduleMeeting : ComponentBase
{
	[Inject]
	private IJSRuntime _jsRuntimeAsync { get; set; } = default!;
	private IJSInProcessRuntime _jsRuntime => (IJSInProcessRuntime)_jsRuntimeAsync;

	[Parameter]
	public string Link { get; set; } = null!;

	protected override void OnAfterRender(bool firstRender)
	{
		string link = $"https://calendly.com/tsvetan-igov/{Link}?background_color=090326&text_color=ffffff&primary_color=573ce2";
		_jsRuntime.InvokeVoid("initCalendly", link);
	}
}