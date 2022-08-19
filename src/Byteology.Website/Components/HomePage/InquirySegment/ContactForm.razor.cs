namespace Byteology.Website.Components.HomePage.InquirySegment;

using Byteology.Website.Inquiring;

public partial class ContactForm : ByteologyComponent
{
    [Inject]
    private IInquiryService _inquiryService { get; set; } = default!;

    private readonly InquiryModel _inquiryModel = new();

    [Parameter, Required]
    public string ConcentText { get; set; } = default!;

    [Parameter, Required]
    public string SubmitInquiryText { get; set; } = default!;

    private async Task onSubmit()
    {
        if (!string.IsNullOrEmpty(_inquiryModel.Honeycomb))
            return;

        bool result = false;
        try
        {
            result = await _inquiryService.SendInquiryAsync(_inquiryModel);
        }
        catch { /* We don't want to expose details about the error. */ }
    }
}
