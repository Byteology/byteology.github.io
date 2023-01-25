namespace Byteology.Website.Tools;

using System.Globalization;

public class StylableComponent : ComponentBase
{
	[Parameter(CaptureUnmatchedValues = true)]
	public Dictionary<string, object>? AdditionalAttributes { get; set; }

	protected string CssClass
	{
		get
		{
			if (AdditionalAttributes != null &&
			    AdditionalAttributes.TryGetValue("class", out var @class) &&
			    !string.IsNullOrEmpty(Convert.ToString(@class, CultureInfo.InvariantCulture)))
			{
				return $"{@class}";
			}

			return string.Empty;
		}
	}

	protected string CssStyle
	{
		get
		{
			if (AdditionalAttributes != null &&
			    AdditionalAttributes.TryGetValue("style", out var style) &&
			    !string.IsNullOrEmpty(Convert.ToString(style, CultureInfo.InvariantCulture)))
			{
				return $"{style}";
			}

			return string.Empty;
		}
	}
}
