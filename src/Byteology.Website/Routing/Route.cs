namespace Byteology.Website.Routing;

public class Route
{
    private readonly List<string> _uriSegments;

    public Type Handler { get; private set; }

    public Route(IEnumerable<string> uriSegments, Type handler)
    {
        _uriSegments = new List<string>(uriSegments);
        Handler = handler;
    }

    public bool Match(IList<string> segments)
    {
        if (segments.Count != _uriSegments.Count)
            return false;

        for (int i = 0; i < _uriSegments.Count; i++)
            if (string.Compare(segments[i], _uriSegments[i], StringComparison.OrdinalIgnoreCase) != 0)
                return false;

        return true;
    }

    public bool Match(Type handler)
    {
        return handler == Handler;
    }

    public string GetUrl()
    {
        return $"/{string.Join("/", _uriSegments)}";
    }
}
