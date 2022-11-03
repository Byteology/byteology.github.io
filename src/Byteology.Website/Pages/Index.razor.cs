namespace Byteology.Website.Pages;

public partial class Index : ComponentBase
{
    private readonly Model _model;
    private readonly Head.Model _head;

    public Index()
    {
        _head = new Head.Model(
            Title: "Byteology - a moment of science",
            Description: "By introducing scientific generalization to software engineering, Byteology helps businesses tackle software complexity and grow.",
            Keywords: new string[] { "scientific generalization", "software development", "research", "proof of concept", "poc", "microservices", "migration to microservices", "event sourcing", "consulting", "training", "interviewing", "interviewing as a service" });

        _model = new Model(
            CallToActionTitle: "Here's to working together",
            CallToAction: "Don't hesitate to reach out to us with any request and we will help you the best we can. We usually answer within 2 business days."
        );
    }

    private sealed record Model(string CallToActionTitle, string CallToAction);
}
