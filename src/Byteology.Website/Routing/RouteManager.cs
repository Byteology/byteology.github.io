namespace Byteology.Website.Routing;

using System.Reflection;
using System.Text.RegularExpressions;

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
            List<string> segments = pageType.FullName!.Substring(pageType.FullName.IndexOf("Pages") + 6).Split('.').ToList();
            if (segments.Last().ToLower() == "index")
                segments.RemoveAt(segments.Count - 1);

            segments = segments.Select(x => pascalToKebabCase(x)).ToList();

            //if (segments.Any())
            //    segments.Insert(0, "#!");

            Route newRoute = new(segments, pageType);
            routesList.Add(newRoute);
        }

        _routes = routesList.ToArray();
    }

    public Route? Match(IList<string> segments)
    {
        foreach (Route route in _routes)
            if (route.Match(segments))
                return route;

        return null;
    }

    public Route? Match<TPage>()
    {
        foreach (Route route in _routes)
            if (route.Match(typeof(TPage)))
                return route;

        return null;
    }

    public Route? Match(Type type)
    {
        foreach (Route route in _routes)
            if (route.Match(type))
                return route;

        return null;
    }

    private static string pascalToKebabCase(string value)
    {
        if (string.IsNullOrEmpty(value))
            return value;

        return Regex.Replace(
            value,
            "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])",
            "-$1",
            RegexOptions.Compiled)
            .Trim()
            .ToLower();
    }
}