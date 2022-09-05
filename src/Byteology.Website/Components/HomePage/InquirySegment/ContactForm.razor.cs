namespace Byteology.Website.Components.HomePage.InquirySegment;

using Byteology.Website.Inquiring;

public partial class ContactForm
{
    [Inject]
    private IInquiryService _inquiryService { get; set; } = default!;

    private readonly InquiryModel _inquiryModel = new();

    [Parameter]
    public string ConcentText { get; set; } = default!;

    [Parameter]
    public string SubmitInquiryText { get; set; } = default!;

    [Parameter]
    public EventCallback<SubmissionEventArgs> OnSubmit { get; set; }

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

        await OnSubmit.InvokeAsync(new SubmissionEventArgs(result));
    }

    public class SubmissionEventArgs : EventArgs
    {
        public bool Success { get; private set; }

        public SubmissionEventArgs(bool success)
        {
            Success = success;
        }
    }
}
