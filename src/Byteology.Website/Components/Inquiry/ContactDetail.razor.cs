namespace Byteology.Website.Components.Inquiry;

public partial class ContactDetail
{
    [Parameter, EditorRequired]
    public Model Detail { get; set; } = default!;

    public record Model(DetailType Type, string Value);

    public enum DetailType
    {
        Address,
        Phone,
        Email
    }
}
