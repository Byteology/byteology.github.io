namespace Byteology.Website.Components.Inquiry;

using Byteology.Website.Inquiring;
using Byteology.Website.Models.Inquiry;

public partial class ContactForm
{
    [Inject]
    private IInquiryService _inquiryService { get; set; } = default!;

    private readonly InquiryData _inquiryData = new();

    [Parameter]
    public ContactFormModel Model { get; set; } = default!;

    [Parameter]
    public EventCallback<SubmissionEventArgs> OnSubmit { get; set; }

    private async Task onSubmit()
    {
        if (!string.IsNullOrEmpty(_inquiryData.Honeycomb))
            return;

        bool result = false;
        try
        {
            result = await _inquiryService.SendInquiryAsync(_inquiryData);
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
