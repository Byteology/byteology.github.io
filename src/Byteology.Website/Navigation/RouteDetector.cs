namespace Byteology.Website.Navigation;

using System.Reflection;

public static class RouteDetector
{
	public static string Match<TPage>() => Match(typeof(TPage));

	public static string Match(Type type)
	{
		IEnumerable<RouteAttribute> attribute = type.GetCustomAttributes<RouteAttribute>();
		return attribute.First().Template;
	}
}
