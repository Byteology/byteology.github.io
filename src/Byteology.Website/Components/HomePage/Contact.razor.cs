namespace Byteology.Website.Components.HomePage;

using Byteology.Website.Inquiring;

public partial class Contact : ComponentBase
{
    [Inject]
    private IInquiryService _inquiryService { get; set; } = default!;

    private InquiryModel _inquiryModel = new();

    private async Task OnSubmit()
    {
        bool result = await _inquiryService.SendInquiryAsync(_inquiryModel);
    }
}
