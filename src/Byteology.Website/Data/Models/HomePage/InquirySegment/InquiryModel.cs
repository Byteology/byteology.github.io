namespace Byteology.Website.Data.Models.HomePage.InquirySegment;
public record InquiryModel(
    string? Title,
    string? CallToAction,
    ContactFormModel ContactForm,
    ContactModel[] Contacts);
