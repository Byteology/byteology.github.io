namespace Byteology.Website.Components.HomePage;

public partial class ServicesList : ComponentBase
{
    [Parameter]
    public ServicesListModel Model { get; set; } = default!;

    private int _checkedIndex = 0;

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (Model == null)
            throw new ArgumentNullException(nameof(Model));
    }
}
