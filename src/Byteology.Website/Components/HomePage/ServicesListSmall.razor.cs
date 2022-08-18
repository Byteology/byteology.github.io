namespace Byteology.Website.Components.HomePage;

public partial class ServicesListSmall : ComponentBase
{
    [Parameter]
    public ServicesListModel Model { get; set; } = default!;

    [Parameter]
    public string? Class { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? InputAttributes { get; set; }


    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (Model == null)
            throw new ArgumentNullException(nameof(Model));
    }
}
