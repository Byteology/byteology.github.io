namespace Byteology.Website.Data.Models.HomePage.InquirySegment;

public record ContactFormModel(
    string? Consent,
    string? SubmitText,
    string? OnSuccessTitle,
    string? OnSuccessBody,
    string? OnErrorTitle,
    string? OnErrorBody,
    string? OnErrorButtonText);
