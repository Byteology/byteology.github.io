namespace Byteology.Website.Data.Models.HomePage.InquirySegment;
public record ContactModel(
    string? Name,
    string? Title,
    ContactDetailModel[] Details
);
