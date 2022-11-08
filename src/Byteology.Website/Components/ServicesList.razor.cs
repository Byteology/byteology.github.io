namespace Byteology.Website.Components;

using Byteology.Website.Pages.Services;

public partial class ServicesList : StyleableComponent
{
    private readonly ServiceModel[] _services;

    public ServicesList()
    {
        _services = new ServiceModel[]
        {
            new ServiceModel(
                Title: "Software Development",
                Description: "We will develop your application or minimum viable product (MVP) by applying scientific generalization and domain-driven design principles.",
                LinkText: "Learn More",
                Page: typeof(SoftwareDevelopment),
                Icon: typeof(Icons.SoftwareDevelopment.Icon)),
            new ServiceModel(
                Title: "Research & PoC",
                Description: "Byteology's team will do any research or proof of contept on your behalf. We'll valdiate your idea, explore feasible approaches and identify potential risks and roadblocks.",
                LinkText: "Learn More",
                Page: typeof(ResearchAndPoc),
                Icon: typeof(Icons.ResearchAndPoc.Icon)),
            new ServiceModel(
                Title: "Migration to Microservices",
                Description: "We have researched and designed strategies and processes that help businesses successfully migrate to microservices.",
                LinkText: "Learn More",
                Page: typeof(MigrationToMicroservices),
                Icon: typeof(Icons.MigrationToMicroservices.Icon)),
            new ServiceModel(
                Title: "Event Sourcing",
                Description: "Standard software development methodologies store and utilize less than 50% of the data that runs through the system.",
                LinkText: "Learn More",
                Page: typeof(EventSourcing),
                Icon: typeof(Icons.EventSourcing.Icon)),
            new ServiceModel(
                Title: "Consulting & Training",
                Description: "Byteology will provide you with tailored consulting services and/or personnel training to help your business scale and grow.",
                LinkText: "Learn More",
                Page: typeof(ConsultingAndTraining),
                Icon: typeof(Icons.ConsultingAndTraining.Icon)),
            new ServiceModel(
                Title: "Interviewing as a Service",
                Description: "We've been studying the process of identifying great software engineers for over a decade. Our team will conduct technical and social interviews on your behalf so you can focus of your core business.",
                LinkText: "Learn More",
                Page: typeof(InterviewingAsAService),
                Icon: typeof(Icons.InterviewingAsAService.Icon)),
        };
    }

    private sealed record ServiceModel(string Title, string Description, string LinkText, Type Page, Type Icon);
}
