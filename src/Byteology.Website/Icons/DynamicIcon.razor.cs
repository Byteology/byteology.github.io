namespace Byteology.Website.Icons;

using System.Reflection;

public partial class DynamicIcon : ComponentBase
{
	[Parameter, EditorRequired]
	public string Name { get; set; } = default!;

	private Type? _iconType;

	protected override void OnParametersSet()
	{
		base.OnParametersSet();

		string? currentNamespace = typeof(DynamicIcon).Namespace;
		string fullName = $"{currentNamespace}.{Name}";

		Assembly assembly = typeof(DynamicIcon).Assembly;
		_iconType = assembly.GetType(fullName, false, true);
	}
}