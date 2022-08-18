namespace Byteology.Website.Components.HomePage;

public partial class ServicesList : ComponentBase
{
    [Parameter]
    public ServicesListModel Model { get; set; } = default!;

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (Model == null)
            throw new ArgumentNullException(nameof(Model));
    }
}
