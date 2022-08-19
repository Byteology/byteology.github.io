namespace Byteology.Website.Components.HomePage;

public partial class ContactsList : ComponentBase
{
    [Parameter]
    public string? CallToAction { get; set; }

    [Parameter]
    public ContactModel[] Contacts { get; set; } = Array.Empty<ContactModel>();

    [Parameter]
    public string? Class { get; set; }
}
