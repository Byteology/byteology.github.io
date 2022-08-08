namespace Byteology.Website.Components.HomePage;

public partial class ScientificGeneralization : ComponentBase
{
    [Parameter]
    public ScientificGeneralizationModel Model { get; set; } = default!;

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        #pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            if (Model == null)
                throw new ArgumentNullException(nameof(Model));
        #pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 
    }
}
