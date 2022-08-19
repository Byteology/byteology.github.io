namespace Byteology.Website.Components;

using System.ComponentModel.DataAnnotations;
using System.Globalization;

public class ByteologyComponent : ComponentBase
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

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        List<ValidationResult> validationResults = new();
        Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true);

        if (validationResults.Any())
            throw new AggregateException(validationResults.Select(r => new ArgumentException(r.ErrorMessage)));

    }
}
