namespace Byteology.Website.Components;

public partial class Footer : StyleableComponent
{
    private readonly Model _model;

    public Footer()
    {
        _model = new Model(
            Copyright: $"@ {DateTime.Now.Year} Byteology",
            PrivacyPolicyText: "Privacy policy"
        );
    }

    private sealed record Model(string Copyright, string PrivacyPolicyText);
}
