namespace Byteology.Website.Components.Inquiry;

using Byteology.Website.Inquiring;

public partial class ContactForm : StyleableComponent
{
    private readonly Model _model;
    private readonly InquiryData _inquiryData = new();

    [Inject]
    private IInquiryService _inquiryService { get; set; } = default!;

    [Parameter]
    public EventCallback<SubmissionEventArgs> OnSubmit { get; set; }

    public ContactForm()
    {
        _model = new Model(
            NameLabel: "Name",
            NamePlaceholder: "John Doe",
            EmailLabel: "Email",
            EmailPlaceholder: "exaple@mail.com",
            MessageLabel: "Message",
            MessagePlaceholder: "Type your message here...",
            Consent: "I freely give my consent to have my personal information processed for the purpose of receiving feedback or solicited content.",
            SubmitText: "Let's talk"
        );
    }

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

    private sealed record Model(
        string NameLabel,
        string NamePlaceholder,
        string EmailLabel,
        string EmailPlaceholder,
        string MessageLabel,
        string MessagePlaceholder,
        string Consent,
        string SubmitText);
}
