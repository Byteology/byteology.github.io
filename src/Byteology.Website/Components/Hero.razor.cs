namespace Byteology.Website.Components;

public partial class Hero : ComponentBase
{
    private readonly Model _model;
    public Hero()
    {
        _model = this.ReadJsonModel<Model>();
    }

    private sealed record Model(string Introduction, string[] Timeline, string LinkText);
}

