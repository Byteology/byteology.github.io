namespace Byteology.Website.FullPageScrolling;

public class SwipeContext
{
    private bool _atBottomOfSlide;
    private bool _atTopOfSlide;

    private double _initialTouchX;
    private double _initialTouchY;

    private readonly int _threshold;

    public bool SwipeStarted { get; set; }

    public double DiffX { get; set; }
    public double DiffY { get; set; }

    public SwipeContext(int threshold)
    {
        _threshold = threshold;
    }

    public void Start(TouchEventArgs args, Slide currentSlide)
    {
        if (args.Touches.Length != 1)
            reset();
        else
        {
            SwipeStarted = true;

            _atBottomOfSlide = currentSlide.BottomIsVisible;
            _atTopOfSlide = currentSlide.TopIsVisible;

            _initialTouchX = args.Touches.Single().ClientX;
            _initialTouchY = args.Touches.Single().ClientY;

            DiffX = 0;
            DiffY = 0;
        }
    }

    public void Move(TouchEventArgs args)
    {
        if (!SwipeStarted)
            return;

        if (args.Touches.Length != 1)
        {
            reset();
            return;
        }

        double newX = args.Touches.Single().ClientX;
        double newY = args.Touches.Single().ClientY;

        DiffX = newX - _initialTouchX;
        DiffY = newY - _initialTouchY;
    }

    public int End()
    {
        int result = 0;

        if (SwipeStarted)
        {
            if (DiffY >= _threshold && _atTopOfSlide)
                result = -1;
            else if (DiffY <= -_threshold && _atBottomOfSlide)
                result = 1;
        }

        reset();
        return result;
    }

    private void reset()
    {
        SwipeStarted = false;

        _atBottomOfSlide = false;
        _atTopOfSlide = false;

        _initialTouchX = 0;
        _initialTouchY = 0;

        DiffX = 0;
        DiffY = 0;
    }
}
