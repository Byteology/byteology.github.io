namespace Byteology.Website.Icons;

using System.Reflection;

public partial class DynamicIcon : ComponentBase
{
	[Parameter, EditorRequired]
	public string Name { get; set; } = default!;

	[Parameter]
	public Type? DefaultIcon { get; set; }

	private Type? _iconType;

	protected override void OnParametersSet()
	{
		base.OnParametersSet();

		string? currentNamespace = typeof(DynamicIcon).Namespace;
		string fullName = $"{currentNamespace}.{Name}";

		Assembly assembly = typeof(DynamicIcon).Assembly;
		_iconType = assembly.GetType(fullName, false, true);

		if (_iconType == null && !fullName.EndsWith("Icon"))
		{
			fullName += "Icon";
			_iconType = assembly.GetType(fullName, false, true);
		}

		Console.WriteLine($"{fullName} - {_iconType?.Name} - {DefaultIcon?.Name}");

		if (_iconType == null)
			_iconType = DefaultIcon;
	}
}