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

    private void onClicked(int serviceIndex)
    {
        _checkedIndex = serviceIndex;
    }

    private void onKeyPressed(KeyboardEventArgs args, int serviceIndex)
    {
        if (args.Code == "Enter" || args.Code == "NumpadEnter") 
            _checkedIndex = serviceIndex;
    }

    private bool serviceIsSelected(int serviceIndex) => serviceIndex == _checkedIndex;
}
