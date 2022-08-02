namespace Byteology.Website.FullPageScrolling;

using Microsoft.JSInterop;

public partial class FullPageScrollingLayout : LayoutComponentBase, IAsyncDisposable
{
    [Inject]
    private IJSRuntime _jsRuntime { get; set; } = default!;
    private IJSObjectReference? _module { get; set; }

    private int _currentSlide = 0;
    private readonly List<Slide> _slides = new();

    private readonly SwipeContext _swipeContext = new(100);
    private readonly WheelContext _wheelContext = new(TimeSpan.FromSeconds(1));

    public VisualViewport VisualViewport { get; private set; } = default!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _module = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "./js/full-page-scrolling-layout.js");
            await _module.InvokeVoidAsync("init");
        }
    }

    public void RegisterSlide(Slide slide)
    {
        _slides.Add(slide);
    }

    private void onWheel(WheelEventArgs args)
    {
        _currentSlide += _wheelContext.Spin(args);
        _currentSlide = Math.Max(0, Math.Min(_slides.Count - 1, _currentSlide));
    }

    private void onTouchStart(TouchEventArgs args)
    {
        _swipeContext.Start(args, _slides[_currentSlide]);
    }

    private void onTouchMove(TouchEventArgs args)
    {
        _swipeContext.Move(args);
    }

    private void onTouchEnd(TouchEventArgs args)
    {
        _currentSlide += _swipeContext.End();
        _currentSlide = Math.Max(0, Math.Min(_slides.Count - 1, _currentSlide));
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore();
        GC.SuppressFinalize(this);
    }

    protected virtual async ValueTask DisposeAsyncCore()
    {
        if (_module != null)
            await _module.InvokeVoidAsync("dispose");
    }
}
