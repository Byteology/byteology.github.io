namespace Byteology.Website.Navigation;

using System.Reflection;

public partial class Sitemap : ComponentBase
{
	[Parameter]
	public bool Detached { get; set; }

	public static string GetRouteOf<TPage>() => GetRouteOf(typeof(TPage));

	public static string GetRouteOf(Type type)
	{
		IEnumerable<RouteAttribute> attribute = type.GetCustomAttributes<RouteAttribute>();
		return attribute.First().Template;
	}

}
