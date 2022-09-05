namespace Byteology.Website.Models.Inquiry;

public record ContactModel(
    string? Name,
    string? Title,
    ContactDetailModel[] Details
);
