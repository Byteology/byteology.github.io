namespace Byteology.Website.Services;

using Byteology.Website.Navigation;
using Byteology.Website.Tools;

public partial class ServicesList : StylableComponent
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
                Url: RouteDetector.Match<SoftwareDevelopmentPage>(),
                Icon: typeof(Icons.SoftwareDevelopment.Icon)),
            new ServiceModel(
                Title: "Research & PoC",
                Description: "Byteology's team will do any research or proof of concept on your behalf. We'll validate your idea, explore feasible approaches and identify potential risks and roadblocks.",
                LinkText: "Learn More",
                Url: RouteDetector.Match<ResearchAndPocPage>(),
                Icon: typeof(Icons.ResearchAndPoc.Icon)),
            new ServiceModel(
                Title: "Migration to Microservices",
                Description: "We have researched and designed strategies and processes that help businesses successfully migrate to microservices.",
                LinkText: "Learn More",
                Url: RouteDetector.Match<MigrationToMicroservicesPage>(),
                Icon: typeof(Icons.MigrationToMicroservices.Icon)),
            new ServiceModel(
                Title: "Event Sourcing",
                Description: "Standard software development methodologies store and utilize less than 50% of the data that runs through the system.",
                LinkText: "Learn More",
                Url: RouteDetector.Match<EventSourcingPage>(),
                Icon: typeof(Icons.EventSourcing.Icon)),
            new ServiceModel(
                Title: "Education & Training",
                Description: "Byteology will provide you with a number of tailored personnel training services to help your business scale and grow.",
                LinkText: "Learn More",
                Url: RouteDetector.Match<EducationAndTrainingPage>(),
                Icon: typeof(Icons.EducationAndTraining.Icon)),
            new ServiceModel(
                Title: "Interviewing as a Service",
                Description: "We've been studying the process of identifying great software engineers for over a decade. Our team will conduct technical and social interviews on your behalf so you can focus of your core business.",
                LinkText: "Learn More",
                Url: RouteDetector.Match<InterviewingAsAServicePage>(),
                Icon: typeof(Icons.InterviewingAsAService.Icon)),
        };
    }

    private sealed record ServiceModel(string Title, string Description, string LinkText, string Url, Type Icon);
}
