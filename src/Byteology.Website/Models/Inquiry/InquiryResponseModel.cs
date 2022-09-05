namespace Byteology.Website.Models.Inquiry;

public record InquiryResponseModel(
    string OnSuccessTitle,
    string OnSuccessBody,
    string OnErrorTitle,
    string OnErrorBody,
    string OnErrorButtonText);