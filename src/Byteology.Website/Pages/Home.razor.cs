namespace Byteology.Website.Pages;

[Route("/")]
public partial class Home : BasePage
{
    private Timeline _scientificGeneralizationTimeline = default!;

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);

        if (firstRender)
        {
            _scientificGeneralizationTimeline.Add(new MarkupString("We think deeply and <strong>analyze the building blocks</strong> of your software architecture"));
            _scientificGeneralizationTimeline.Add(new MarkupString("We extrapolate <strong>actionable data and insights</strong>"));
            _scientificGeneralizationTimeline.Add(new MarkupString("We design and implement <strong>tailored solutions</strong>"));
            _scientificGeneralizationTimeline.Add(new MarkupString("We help your business <strong>scale and grow</strong>"));
        }
    }
}
