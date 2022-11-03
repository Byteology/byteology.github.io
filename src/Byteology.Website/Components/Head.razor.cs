namespace Byteology.Website.Components;

public partial class Head : ComponentBase
{
    [Parameter, EditorRequired]
    public Model Data { get; set; } = null!;

    public record Model(string Title, string Description, string[] Keywords);
}
