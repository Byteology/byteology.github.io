namespace Byteology.Website.Inquiry;

public partial class CalendlyForm : ComponentBase
{
	[Parameter(CaptureUnmatchedValues = true)]
	public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }
}
