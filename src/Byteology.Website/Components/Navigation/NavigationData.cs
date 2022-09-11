namespace Byteology.Website.Components.Navigation;

using Byteology.Website.Pages.Services;

public class NavigationData
{
    public NavigationSection[] Sections { get; private set; }
    public NavigationItemModel Highlighted { get; private set; }

    public NavigationData()
    {
        Sections = new NavigationSection[]
        {
            new NavigationSection("Company", typeof(Pages.Index), new NavigationItemModel[] 
            {
                new NavigationItemModel("Mission", typeof(Mission)),
                new NavigationItemModel("Careers", typeof(Careers)) 
            }, true),
            new NavigationSection("Services", typeof(Index), new NavigationItemModel[]
            {
                new NavigationItemModel("Software Development", typeof(SoftwareDevelopment)),
                new NavigationItemModel("Research & PoC", typeof(ResearchAndPoc)),
                new NavigationItemModel("Migration to Microservices", typeof(MigrationToMicroservices)),
                new NavigationItemModel("Event Sourcing", typeof(EventSourcing)),
                new NavigationItemModel("Consulting & Training", typeof(ConsultingAndTraining)),
                new NavigationItemModel("Interviewing as a Service", typeof(InterviewingAsAService)),
            }),
        };

        Highlighted = new NavigationItemModel("Contact us", typeof(Contacts));
    }

    public record NavigationSection(string Text, Type Page, NavigationItemModel[] Items, bool Expand = false);
    public record NavigationItemModel(string Text, Type Page);
}

