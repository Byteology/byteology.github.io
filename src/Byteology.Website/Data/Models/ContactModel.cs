namespace Byteology.Website.Data.Models;

public record ContactModel(
    string? Name,
    string? Title,
    ContactDetailModel[] Details
);
