namespace Byteology.Website.Data.Models;

public record InquiryModel(
    string? Title,
    string? CallToAction, 
    string? Consent,
    string? SubmitInquiryText,
    ContactModel[] Contacts);
