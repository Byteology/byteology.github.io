namespace Byteology.Website.Components.HomePage;

public partial class Service : ComponentBase
{
    [Parameter]
    public ServiceModel Model { get; set; } = default!;

    [Parameter]
    public ServiceLayout Layout { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? InputAttributes { get; set; }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (Model == null)
            throw new ArgumentNullException(nameof(Model));
    }

    public enum ServiceLayout
    {
        Button,
        ButtonSelected,
        Card,
        Article
    }
}

