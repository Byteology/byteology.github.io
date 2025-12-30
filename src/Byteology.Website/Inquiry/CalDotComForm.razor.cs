namespace Byteology.Website.Inquiry;

public partial class CalDotComForm : ComponentBase
{
	[Parameter(CaptureUnmatchedValues = true)]
	public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }
}
