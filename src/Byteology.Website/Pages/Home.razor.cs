namespace Byteology.Website.Pages;

using Microsoft.JSInterop;

public partial class Home : ComponentBase, IAsyncDisposable
{
    [Inject]
    private IJSRuntime _jsRuntime { get; set; } = default!;

    private IJSObjectReference? _module { get; set; }

    private int _currentSlide = 0;
    private readonly Slide[] _slides = new Slide[3];

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _module = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "./js/home-page.js");
            await _module.InvokeVoidAsync("init");
        }
    }

    private bool _wheelDownDisabled = false;
    private bool _wheelUpDisabled = false;
    private void onWheel(WheelEventArgs args)
    {
        if (args.CtrlKey)
            return;

        if (args.DeltaY > 0)
        {
            _wheelUpDisabled = false;
            if (_wheelDownDisabled)
                return;

            tryIncrementSlide();
            _wheelDownDisabled = true;
            _ = Task.Delay(TimeSpan.FromSeconds(1)).ContinueWith(t => _wheelDownDisabled = false);
        }
        else if (args.DeltaY < 0)
        {
            _wheelDownDisabled = false;
            if (_wheelUpDisabled)
                return;

            tryDecrementSlide();
            _wheelUpDisabled = true;
            _ = Task.Delay(TimeSpan.FromSeconds(1)).ContinueWith(t => _wheelUpDisabled = false);
        }
    }


    double? _touchStartX, _touchStartY;
    private void onTouchStart(TouchEventArgs args)
    {
        if (args.Touches.Length != 1)
        {
            _touchStartX = null;
            _touchStartY = null;
            return;
        }

        _touchStartX = args.Touches.Single().ClientX;
        _touchStartY = args.Touches.Single().ClientY;
    }

    private void onTouchMove(TouchEventArgs args)
    {
        if (args.Touches.Length != 1 || !_touchStartX.HasValue || !_touchStartY.HasValue)
            return;

        double newX = args.Touches.Single().ClientX;
        double newY = args.Touches.Single().ClientY;

        double xDiff = _touchStartX.Value - newX;
        double yDiff = _touchStartY.Value - newY;

        if (Math.Abs(xDiff) < Math.Abs(yDiff))
        {
            if (yDiff > 0)
                tryIncrementSlide();
            else if (yDiff < 0)
                tryDecrementSlide();
        }

        _touchStartX = null;
        _touchStartY = null;
    }

    private void onTouchEnd(TouchEventArgs args)
    {
        _touchStartX = null;
        _touchStartY = null;
    }

    private void tryIncrementSlide()
    {
        if (_currentSlide != _slides.Length - 1 && _slides[_currentSlide].BottomIsVisible)
            _currentSlide++;
    }

    private void tryDecrementSlide()
    {
        if (_currentSlide != 0 && _slides[_currentSlide].TopIsVisible)
            _currentSlide--;
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
