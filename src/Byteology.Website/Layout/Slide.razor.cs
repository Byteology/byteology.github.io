namespace Byteology.Website.Layout;

using Ljbc1994.Blazor.IntersectionObserver;
using Ljbc1994.Blazor.IntersectionObserver.API;
using Microsoft.JSInterop;

public partial class Slide : ComponentBase
{
	private ElementReference _slide;

	private bool _isIntersecting;

	private IIntersectionObserverService _observer { get; set; } = default!;

	[Inject]
	private IJSRuntime _jsRuntime { get; set; } = default!;

	[Inject]
	private NavigationManager _navManager { get; set; } = default!;

	[Inject]
	private LayoutStateContainer _state { get; set; } = default!;

	[Parameter]
	public bool IncludeFooter { get; set; }

	[Parameter]
	public RenderFragment? ChildContent { get; set; }

	protected override async Task OnAfterRenderAsync(bool firstRender)
	{
		await base.OnAfterRenderAsync(firstRender);

		if (firstRender)
			await setupObserver();
	}

	public async Task setupObserver()
	{
		_observer = new IntersectionObserverService(_jsRuntime, _navManager);
		await _observer.Observe(_slide, (entries) =>
		{
			IntersectionObserverEntry? entry = entries.FirstOrDefault();
			_isIntersecting = entry?.IsIntersecting ?? false;
			StateHasChanged();
		});
	}

}
