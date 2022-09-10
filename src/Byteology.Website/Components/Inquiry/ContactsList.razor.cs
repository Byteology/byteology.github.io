namespace Byteology.Website.Components.Inquiry;

public partial class ContactsList : ComponentBase
{
    private readonly ContactModel[] _contacts;

    public ContactsList()
    {
        _contacts = this.ReadJsonModel<ContactModel[]>();
    }

    public record ContactModel(
        string? Name,
        string? Title,
        ContactDetail.Model[] Details
    );
}
