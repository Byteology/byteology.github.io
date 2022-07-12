namespace Byteology.Website.Pages;

public partial class Counter : ComponentBase
{
    private int _currentCount = 0;

    private void incrementCount()
    {
        _currentCount++;
    }
}
