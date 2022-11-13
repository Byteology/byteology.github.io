namespace Byteology.Website.Routing;

using System.Reflection;

public static class RouteManager
{
    public static string? Match<TPage>() => Match(typeof(TPage));

    public static string? Match(Type type)
    {
        RouteAttribute? attribute = type.GetCustomAttribute<RouteAttribute>();
        return attribute?.Template;
    }
}