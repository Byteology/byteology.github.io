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
        _model = this.ReadJsonModel<Model>();
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
        string SubmitText,
        string OnSuccessTitle,
        string OnSuccessBody,
        string OnErrorTitle,
        string OnErrorBody,
        string OnErrorButtonText);
}
