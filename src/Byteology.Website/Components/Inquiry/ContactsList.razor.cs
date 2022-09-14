namespace Byteology.Website.Components.Inquiry;

public partial class ContactsList : ComponentBase
{
    private readonly ContactModel[] _contacts;

    public ContactsList()
    {
        _contacts = new ContactModel[]
        {
            new ContactModel(
                Name: "Tsvetan Igov",
                Title: "Founder",
                new ContactDetail.Model[]
                {
                    new ContactDetail.Model(
                        Type: ContactDetail.DetailType.Phone,
                        Value: "+359 876 535 938"),
                    new ContactDetail.Model(
                        Type: ContactDetail.DetailType.Email,
                        Value: "tsvetan.igov@byteology.net"),
                }),
            new ContactModel(
                Name: "Office",
                Title: "Sofia, Bulgaria",
                new ContactDetail.Model[]
                {
                    new ContactDetail.Model(
                        Type: ContactDetail.DetailType.Address,
                        Value: "5 Hristo Belchev str."),
                    new ContactDetail.Model(
                        Type: ContactDetail.DetailType.Email,
                        Value: "contact@byteology.net"),
                }),
        };
    }

    public record ContactModel(
        string Name,
        string Title,
        ContactDetail.Model[] Details
    );
}
