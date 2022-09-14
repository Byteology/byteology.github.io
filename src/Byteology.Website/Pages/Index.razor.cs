﻿namespace Byteology.Website.Pages;

public partial class Index : ComponentBase
{
    private readonly Model _model;

    public Index()
    {
        _model = new Model(
            Title: "Byteology - a moment of science",
            CallToActionTitle: "Here's to working together",
            CallToAction: "Don't hesitate to reach out to us with any request and we will help you the best we can. We usually answer within 2 business days."
        );
    }

    private sealed record Model(string Title, string CallToActionTitle, string CallToAction);
}
