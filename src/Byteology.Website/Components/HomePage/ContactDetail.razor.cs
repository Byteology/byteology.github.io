namespace Byteology.Website.Components.HomePage;

using Byteology.Website.Data.Models;

public partial class ContactDetail : ComponentBase
{
    [Parameter]
    public ContactDetailModel Model { get; set; } = default!;

    [Parameter]
    public string? Class { get; set; } 

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (Model == null)
            throw new ArgumentNullException(nameof(Model));
    }
}
