namespace Byteology.Website.Routing;

using System.Reflection;

public class RouteManager
{
    private readonly Route[] _routes;

    public RouteManager()
    {
        IEnumerable<Type> pageComponentTypes = Assembly.GetExecutingAssembly().ExportedTypes
            .Where(t => 
                t.IsSubclassOf(typeof(ComponentBase)) && 
                t.Namespace!= null && t.Namespace.Contains(".Pages"));

        List<Route> routesList = new();
        foreach (Type pageType in pageComponentTypes)
        {
            string[] segments = pageType.FullName!.Substring(pageType.FullName.IndexOf("Pages") + 6).Split('.');
            if (segments.Last().ToLower() == "index")
                segments = segments.SkipLast(1).ToArray();

            if (segments.Any())
                segments[0] = "#!" + segments[0];

            Route newRoute = new(segments, pageType);
            routesList.Add(newRoute);
        }

        _routes = routesList.ToArray();
    }

    public Route? Match(string[] segments)
    {
        foreach (Route route in _routes)
            if (route.Match(segments))
                return route;

        return null;
    }
}