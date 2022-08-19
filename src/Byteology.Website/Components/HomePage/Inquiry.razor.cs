namespace Byteology.Website.Components.HomePage;

public partial class Inquiry : ComponentBase
{
    [Parameter]
    public InquiryModel Model { get; set; } = default!;

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (Model == null)
            throw new ArgumentNullException(nameof(Model));
    }
}
