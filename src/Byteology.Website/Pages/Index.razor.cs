namespace Byteology.Website.Pages;

public partial class Index : ComponentBase
{
    private readonly Model _model;

    public Index()
    {
        _model = new Model(
            Title: "Byteology - a moment of science"
        );
    }

    private sealed record Model(string Title);
}
