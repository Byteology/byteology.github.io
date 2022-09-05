namespace Byteology.Website.Models.Inquiry;

public record ContactFormModel(
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
