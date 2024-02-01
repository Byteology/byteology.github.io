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
		_jsRuntime.InvokeVoid("initCalendly", Link);
	}
}