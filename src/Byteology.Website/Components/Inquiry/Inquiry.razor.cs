namespace Byteology.Website.Components.Inquiry;

using Byteology.Website.Models.Inquiry;

public partial class Inquiry : ComponentBase
{
    private bool? _successfulSubmit;
    private bool _shouldFadeIn = false;

    [Inject]
    private ModelReader _modelReader { get; set; } = default!;
    private InquiryModel _model = default!;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        _model = _modelReader.Read<InquiryModel>("inquiry-data.json");
    }

    private void onSubmit(ContactForm.SubmissionEventArgs args)
    {
        _successfulSubmit = args.Success;
        _shouldFadeIn = true;
    }

    private string getLightboxTitle()
    {
        string? result = null;

        if (_successfulSubmit.HasValue)
            result = _successfulSubmit.Value ? _model.Response.OnSuccessTitle : _model.Response.OnErrorTitle;

        return result ?? string.Empty;
    }

    private string getLightboxBody()
    {
        string? result = null;

        if (_successfulSubmit.HasValue)
            result = _successfulSubmit.Value ? _model.Response.OnSuccessBody : _model.Response.OnErrorBody;

        return result ?? string.Empty;
    }
}
