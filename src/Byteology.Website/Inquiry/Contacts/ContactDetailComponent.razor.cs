namespace Byteology.Website.Inquiry.Contacts;

public partial class ContactDetailComponent : ComponentBase
{
	[Parameter, EditorRequired]
	public ContactDetail Detail { get; set; } = default!;
}
