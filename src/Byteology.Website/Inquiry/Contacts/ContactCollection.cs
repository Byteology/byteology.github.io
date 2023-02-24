namespace Byteology.Website.Inquiry.Contacts;

public static class ContactCollection
{
	public static Contact Founder { get; } =
		new(Name: "Tsvetan Igov",
		    Title: "Founder",
		    Details: new ContactDetail[]
		    {
			    new(ContactDetailType.Phone, "+359 876 535 938"),
			    new(ContactDetailType.Email, "tsvetan.igov@byteology.net")
		    });

	public static Contact Office { get; } =
		new(Name: "Office",
		    Title: "Sofia, Bulgaria",
		    Details: new ContactDetail[]
		    {
			    new(ContactDetailType.Address, "5 Hristo Belchev str."),
			    new(ContactDetailType.Email, "contact@byteology.net")
		    });

	public static Contact[] InquiryContacts { get; } = new[]
	{
		Founder,
		Office,
	};
}
