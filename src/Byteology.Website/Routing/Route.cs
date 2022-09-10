namespace Byteology.Website.Routing;

public class Route
{
    private readonly string[] _uriSegments;

    public Type Handler { get; private set; }

    public Route(string[] uriSegments, Type handler)
    {
        _uriSegments = uriSegments;
        Handler = handler;
    }

    public bool Match(string[] segments)
    {
        if (segments.Length != _uriSegments.Length)
            return false;

        for (int i = 0; i < _uriSegments.Length; i++)
            if (string.Compare(segments[i], _uriSegments[i], StringComparison.OrdinalIgnoreCase) != 0)
                return false;

        return true;
    }
}
