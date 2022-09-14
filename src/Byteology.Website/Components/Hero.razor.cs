namespace Byteology.Website.Components;

public partial class Hero : StyleableComponent
{
    private readonly Model _model;
    public Hero()
    {
        _model = new Model(
            Introduction: "By introducing **scientific generalization** to software engineering, **Byteology** helps businesses tackle software complexity and grow.",
            Timeline: new string[]
            {
                "We **gather and detail** the information defining your domain",
                "We derive **actionable data and insights**",
                "We design and implement **tailored solutions**",
                "We help your business **scale and grow**"
            },
            LinkText: "Learn More");
    }

    private sealed record Model(string Introduction, string[] Timeline, string LinkText);
}

