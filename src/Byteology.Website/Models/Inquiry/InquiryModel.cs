namespace Byteology.Website.Models.Inquiry;

public record InquiryModel(
    string? Title,
    string? CallToAction,
    ContactModel[] Contacts,
    ContactFormModel ContactForm,
    InquiryResponseModel Response);
