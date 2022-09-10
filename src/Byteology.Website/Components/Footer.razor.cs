namespace Byteology.Website.Components;

public partial class Footer : ComponentBase
{
    private readonly Model _model;

    public Footer()
    {
        _model = this.ReadJsonModel<Model>();
    }

    private sealed record Model(LinkSectionModel[] LinkSections, string Copyright, string PrivacyPolicyText);
    private sealed record LinkSectionModel(string Title, LinkModel[] Links);
    private sealed record LinkModel(string Text, string Url);
}
