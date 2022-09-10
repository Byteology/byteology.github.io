namespace Byteology.Website.Pages;

public partial class Index : ComponentBase
{
    private readonly Model _model;

    public Index()
    {
        _model = this.ReadJsonModel<Model>();
    }

    private sealed record Model(string Title);
}
