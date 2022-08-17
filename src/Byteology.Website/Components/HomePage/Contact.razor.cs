namespace Byteology.Website.Components.HomePage;

using Byteology.Website.Inquiring;

public partial class Contact : ComponentBase
{
    [Inject]
    private IInquiryService _inquiryService { get; set; } = default!;

    private readonly InquiryModel _inquiryModel = new();

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
