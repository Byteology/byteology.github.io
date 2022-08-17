namespace Byteology.Website.Inquiring;

using System.ComponentModel.DataAnnotations;

public class InquiryModel
{
    [Required]
    public string? Name { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    public string? Phone { get; set; }

    [Required]
    public string? Message { get; set; }

    [Range(typeof(bool), "true", "true")]
    public bool Consent { get; set; }
}
