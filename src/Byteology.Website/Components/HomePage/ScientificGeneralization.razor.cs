﻿namespace Byteology.Website.Components.HomePage;

public partial class ScientificGeneralization : ComponentBase
{
    [Parameter]
    public ScientificGeneralizationModel Model { get; set; } = default!;

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (Model == null)
            throw new ArgumentNullException(nameof(Model));
    }
}
