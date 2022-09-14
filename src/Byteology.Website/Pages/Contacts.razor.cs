namespace Byteology.Website.Pages;

public partial class Contacts
{
    private readonly Model _model;

    public Contacts()
    {
        _model = new Model(
            CallToActionTitle: "Here's to working together",
            CallToAction: "Don't hesitate to reach out to us with any request and we will help you the best we can. We usually answer within 2 business days."
        );
    }

    private sealed record Model(string CallToActionTitle, string CallToAction);
}
