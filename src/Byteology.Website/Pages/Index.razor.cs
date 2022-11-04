﻿namespace Byteology.Website.Pages;

public partial class Index : ComponentBase
{
    private readonly Model _model;
    private readonly string _title;
    private readonly string _description;
    private readonly string[] _keywords;

    public Index()
    {
        _title = "Byteology - a moment of science";
        _description = "By introducing scientific generalization to software engineering, Byteology helps businesses tackle software complexity and grow.";
        _keywords = new string[] { "scientific generalization", "software development", "research", "proof of concept", "poc", "microservices", "migration to microservices", "event sourcing", "consulting", "training", "interviewing", "interviewing as a service" };

        _model = new Model(
            CallToActionTitle: "Here's to working together",
            CallToAction: "Don't hesitate to reach out to us with any request and we will help you the best we can. We usually answer within 2 business days."
        );
    }

    private sealed record Model(string CallToActionTitle, string CallToAction);
}
