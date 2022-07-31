namespace Byteology.Website.Components;

using Ljbc1994.Blazor.IntersectionObserver;

public partial class Slide : ComponentBase, IAsyncDisposable
{
    private ElementReference _sectionElement;
    private ElementReference _startElement;
    private ElementReference _endElement;

    [Inject]
    private IIntersectionObserverService _intersectionService { get; set; } = default!;
    private IntersectionObserver? _startElementIntersectionObserver;
    private IntersectionObserver? _endElementIntersectionObserver;

    [Parameter]
    public RenderFragment ChildContent { get; set; } = default!;

    public bool TopIsVisible { get; private set; }
    public bool BottomIsVisible { get; private set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await setupObservers();
        }
    }

    private async Task setupObservers()
    {
        IntersectionObserverOptions options = new()
        {
            Root = _sectionElement,
            Threshold = new List<double>() { 0 }
        };

        _startElementIntersectionObserver = await _intersectionService.Observe(_startElement, (e) =>
        {
            TopIsVisible = e.Single().IsIntersecting;
            StateHasChanged();
        }, options);

        _endElementIntersectionObserver = await _intersectionService.Observe(_endElement, (e) =>
        {
            BottomIsVisible = e.Single().IsIntersecting;
            StateHasChanged();
        }, options);
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore();
        GC.SuppressFinalize(this);
    }

    protected virtual async ValueTask DisposeAsyncCore()
    {
        if (_startElementIntersectionObserver != null)
            await _startElementIntersectionObserver.Dispose();

        if (_endElementIntersectionObserver != null)
            await _endElementIntersectionObserver.Dispose();
    }
}
