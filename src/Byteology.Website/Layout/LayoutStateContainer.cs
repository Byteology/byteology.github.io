namespace Byteology.Website;

public class LayoutStateContainer
{
    public bool Prerendering { get; private set; } = true;
    public bool NavigationBarRendered { get; private set; }

    public void OnLayoutChanged(bool navigationBarRendered)
    {
        Prerendering = false;
        NavigationBarRendered = navigationBarRendered;
    }
}
