namespace Byteology.Website.Tools;

using System.Globalization;

public partial class IconsPage : ComponentBase
{

	private string[] _iconNames = default!;

	private string _name = " ";

	protected override void OnInitialized()
	{
		base.OnInitialized();

		IEnumerable<Type> iconTypes = typeof(IconsPage).Assembly.GetTypes().Where(t => t.Namespace == typeof(Icons.DynamicIcon).Namespace && t != typeof(Icons.DynamicIcon));

		_iconNames = iconTypes.Select(x => x.Name.EndsWith("Icon", true, CultureInfo.InvariantCulture) ? x.Name[..^4] : x.Name).ToArray();
	}

	private void showName(string name)
	{
		_name = name;
	}
}