namespace Byteology.Website.Components.Inquiry;

public partial class Inquiry : StyleableComponent
{
    private bool? _successfulSubmit;
    private bool _shouldFadeIn = false;

    private readonly Model _model;

    public Inquiry()
    {
        _model = new Model(
            Title: "Here's to working together",
            CallToAction: "Don't hesitate to reach out to us with any request and we will help you the best we can. We usually answer within 2 business days.",
            Response: new ResponseModel(
                OnSuccessTitle: "Thank you!",
                OnSuccessBody: "Thank you for reaching out! We'll make sure to help you the best we can. We usually answer within 2 business days.",
                OnErrorTitle: "Oops!",
                OnErrorBody: "We are terribly sorry but something went wrong. You can either retry or just write us a plain old email.",
                OnErrorButtonText: "Continue"));
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

    private sealed record Model(
        string Title,
        string CallToAction,
        ResponseModel Response);

    private sealed record ResponseModel(
        string OnSuccessTitle,
        string OnSuccessBody,
        string OnErrorTitle,
        string OnErrorBody,
        string OnErrorButtonText);
}
