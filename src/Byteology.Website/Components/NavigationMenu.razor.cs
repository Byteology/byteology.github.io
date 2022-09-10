namespace Byteology.Website.Components;

using Byteology.Website.Pages.Services;

public partial class NavigationMenu : ComponentBase
{
    private readonly NavigationItemModel[] _items;

    public NavigationMenu()
    {
        _items = new NavigationItemModel[]
        {
            new NavigationItemModel("Mission", typeof(Mission)),
            new NavigationItemModel("Careers", typeof(Careers)),
            new NavigationItemModel("Services", typeof(Index), new NavigationItemModel[]
            {
                new NavigationItemModel("Software Development", typeof(SoftwareDevelopment)),
                new NavigationItemModel("Research & PoC", typeof(ResearchAndPoc)),
                new NavigationItemModel("Migration to Microservices", typeof(MigrationToMicroservices)),
                new NavigationItemModel("Event Sourcing", typeof(EventSourcing)),
                new NavigationItemModel("Consulting & Training", typeof(ConsultingAndTraining)),
                new NavigationItemModel("Interviewing as a Service", typeof(InterviewingAsAService)),
            }),
            new NavigationItemModel("Contact us", typeof(Contacts), null, true),
        };
    }

    private sealed record NavigationItemModel(string Text, Type Page, NavigationItemModel[]? Subitems = null, bool Highlighted = false);
}
