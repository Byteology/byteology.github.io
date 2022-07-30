namespace Byteology.Website.Pages;

using Microsoft.JSInterop;

public partial class Home : ComponentBase, IAsyncDisposable
{
    [Inject]
    private IJSRuntime _jsRuntime { get; set; } = default!;

    private IJSObjectReference? _module { get; set; }

    private int _currentSlide = 0;
    private readonly int _slidesCount = 3;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _module = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "./js/home-page.js");
            await _module.InvokeVoidAsync("init");
        }
    }

    private bool _throttling = false;

    private void onWheel(WheelEventArgs args)
    {
        if (_throttling)
            return;

        if (args.DeltaY > 0)
            changeSlide(_currentSlide + 1, true);
        else if (args.DeltaY < 0)
            changeSlide(_currentSlide - 1, true);
    }


    double? _touchX, _touchY;
    private void onTouchStart(TouchEventArgs args)
    {
        if (args.Touches.Length != 1)
        {
            _touchX = null;
            _touchY = null;
            return;
        }

        _touchX = args.Touches.Single().ClientX;
        _touchY = args.Touches.Single().ClientY;
    }

    private void onTouchMove(TouchEventArgs args)
    {
        if (args.Touches.Length != 1 || !_touchX.HasValue || !_touchY.HasValue)
            return;

        double newX = args.Touches.Single().ClientX;
        double newY = args.Touches.Single().ClientY;

        double xDiff = _touchX.Value - newX;
        double yDiff = _touchY.Value - newY;

        if (Math.Abs(xDiff) < Math.Abs(yDiff))
        {
            if (yDiff > 0)
                changeSlide(_currentSlide + 1, false);
            else
                changeSlide(_currentSlide - 1, false);

            _throttling = true;
        }

        _touchX = null;
        _touchY = null;
    }

    private void onTouchEnd(TouchEventArgs args)
    {
        _throttling = false;
    }

    private void changeSlide(int slide, bool shouldThrottle)
    {
        slide = Math.Max(0, Math.Min(slide, _slidesCount - 1));

        if (_currentSlide != slide)
        {
            _currentSlide = slide;

            if (shouldThrottle)
            {
                _throttling = true;
                throttle(() => _throttling = false, TimeSpan.FromSeconds(1));
            }
        }
    }

    private static void throttle(Action action, TimeSpan interval)
    {
        _ = Task.Delay(interval).ContinueWith(t => action());
    }


    protected virtual async ValueTask DisposeAsyncCore()
    {
        if (_module != null)
            await _module.InvokeVoidAsync("dispose");
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore();
        GC.SuppressFinalize(this);
    }
}
