namespace Byteology.Website.FullPageScrolling;

public class WheelContext
{
    private bool _wheelDownDisabled = false;
    private bool _wheelUpDisabled = false;
    private TimeSpan _throttle;

    public WheelContext(TimeSpan throttle)
    {
        _throttle = throttle;
    }

    public int Spin(WheelEventArgs args)
    {
        if (args.CtrlKey)
            return 0;

        if (args.DeltaY > 0)
        {
            _wheelUpDisabled = false;
            if (_wheelDownDisabled)
                return 0;

            _wheelDownDisabled = true;
            _ = Task.Delay(_throttle).ContinueWith(t => _wheelDownDisabled = false);
            return 1;
        }
        else if (args.DeltaY < 0)
        {
            _wheelDownDisabled = false;
            if (_wheelUpDisabled)
                return 0;

            _wheelUpDisabled = true;
            _ = Task.Delay(_throttle).ContinueWith(t => _wheelUpDisabled = false);
            return -1;
        }

        return 0;
    }
}
