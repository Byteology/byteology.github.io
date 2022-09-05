namespace Byteology.Website.Components.HomePage.InquirySegment;

using Byteology.Website.Data.Models.HomePage.InquirySegment;

public partial class Inquiry : ComponentBase
{
    private bool? _successfulSubmit;
    private bool _shouldFadeIn = false;

    [Parameter]
    public InquiryModel Model { get; set; } = default!;

    private void onSubmit(ContactForm.SubmissionEventArgs args)
    {
        _successfulSubmit = args.Success;
        _shouldFadeIn = true;
    }

    private string getLightboxTitle()
    {
        string? result = null;

        if (_successfulSubmit.HasValue)
            result = _successfulSubmit.Value ? Model.ContactForm.OnSuccessTitle : Model.ContactForm.OnErrorTitle;

        return result ?? string.Empty;
    }

    private string getLightboxBody()
    {
        string? result = null;

        if (_successfulSubmit.HasValue)
            result = _successfulSubmit.Value ? Model.ContactForm.OnSuccessBody : Model.ContactForm.OnErrorBody;

        return result ?? string.Empty;
    }
}
