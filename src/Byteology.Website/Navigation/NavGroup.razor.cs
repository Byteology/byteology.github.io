namespace Byteology.Website.Navigation;

using System.Text;

public partial class NavGroup : ComponentBase
{
	[Parameter, EditorRequired]
	public NavBarBehaviourType NavBarBehaviour { get; set; }

	[Parameter]
	public bool SitemapVisible { get; set; }

	[Parameter, EditorRequired]
	public RenderFragment ChildContent { get; set; } = default!;

	[Parameter]
	public string? Name { get; set; }

	[Parameter]
	public string? UrlPrefix { get; set; }

	private string getCssClass()
	{
		string result = "";

		if (SitemapVisible)
			result = "sitemap-visible ";

		string navbarBehaviourClass = NavBarBehaviour switch
		{
			NavBarBehaviourType.Collapsed => "navbar-collapsed",
			NavBarBehaviourType.Expanded => "navbar-expanded",
			_ => ""
		};

		result += navbarBehaviourClass;
		result = result.Trim();
		return result;
	}

	public enum NavBarBehaviourType
	{
		Hidden,
		Collapsed,
		Expanded
	}
}
