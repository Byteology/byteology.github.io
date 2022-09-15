namespace Byteology.Website.Pages.Services;

public partial class MigrationToMicroservices
{
    private readonly Intro _introModel;
    private readonly Benefits _benefitsModel;
    private readonly WhenToMigrate _whenToMigrateModel;
    private readonly Migration _migrationModel;
    private readonly string _callToAction;

    public MigrationToMicroservices()
    {
        _introModel = getIntroSection();
        _benefitsModel = getBenefitsSection();
        _whenToMigrateModel = getWhenToMigrateSection();
        _migrationModel = getMigrationSection();
        _callToAction = "If your business requires a migration to a microservice architecture, don't hesitate to reach out to us. Our team of experts can help you take your software to the next level.";
    }

    private static Intro getIntroSection() => new(
        Title: "Migration to Microservices",
        Icon: typeof(Icons.MigrationToMicroservices.Icon),
        Body: "In today’s disruptive web development world, microservices are receiving a lot of attention. Unlike monolithic systems, microservices are designed to scale with changing market demands. Because of that modern enterprises are moving their legacy monolithic systems to microservices architecture."
    );
    private static Benefits getBenefitsSection() => new(
        Title: "Benefits of the Microservice Architecture",
        Body: "As the name suggests, microservices are small units that break up a monolithic application into a set of independent services. Unlike slow and heavy monolithic applications, microservices are faster to develop and deploy. Migrating from a monolithic architecture to a microservices one provides a lot of benefits, most important of which are as follows:",
        Items: new Benefit[]
        {
            new Benefit("Simplicity", "Teams act within a small and well understood context, reducing cognitive complexity and shortening development cycle times.", typeof(Icons.MigrationToMicroservices.Simplicity)),
            new Benefit("Domain Alignment", "Microservices align closely with their respective business domain allowing the use of ubiquitous language thus improving collaboration.", typeof(Icons.MigrationToMicroservices.DomainAlignment)),
            new Benefit("Flexible Scaling", "Microservices allow each service to be independently scaled to meet demand for the application feature it supports.", typeof(Icons.MigrationToMicroservices.FlexibleScaling)),
            new Benefit("Easy Deployment", "Microservices enable continuous integration and continuous delivery, making it easy to try out new ideas and to roll back if something doesn’t work.", typeof(Icons.MigrationToMicroservices.EasyDeployment)),
            new Benefit("Resilience", "Service independence increases an application’s resistance to failure.", typeof(Icons.MigrationToMicroservices.Resilience)),
            new Benefit("Freedom", "Teams have the freedom to choose the best tool to solve their specific problems.", typeof(Icons.MigrationToMicroservices.Freedom)),
        }
    );
    private static WhenToMigrate getWhenToMigrateSection() => new(
        Title: "When to Migrate",
        Body: "Once you have made your mind to embrace microservices, the first question is – when should you make your move? Usually the right time to migrate a monolithic application is when your organization is growing and is facing productivity and scaling issues or when you start experiencing disruption in the communication between teams."
    );
    private static Migration getMigrationSection() => new(
        Title: "How to Migrate",
        Body: "The migration to microservice architecture is a complex process with many pitfalls. To avoid them we have spent years designing and refining a four-step strategy that helps businesses successfully migrate to microservices.",
        Steps: new MigrationStep[]
        {
            new MigrationStep("Process Discovery", new string[]
            {
                "We organize a workshop with your domain experts and engineering team.",
                "Together we map all the business processes that occur in your application.",
                "As an output we create a top-level document (process map) of what your application does and how it does it.",
                "Additionally, we establish a proper domain language and look for type instance homonyms so that domain experts and software engineers will be able to communicate fluently."
            }),
            new MigrationStep("Defining Bounded Contexts", new string[]
            {
                "We use the process map to define entities, aggregates, services, and their bounded contexts.",
                "This gets detailed in a bounded context canvas for each context. It contains the definition of the context, its capabilities, responsibilities, policies, dependencies, and its ubiquitous language.",
                "Using the bounded context canvases we identify proper microservices. Usually they align with the bounded contexts themselves but can range in size anywhere between a single aggregate and a whole bounded context.",
            }),
            new MigrationStep("Establishing Service Boundaries", new string[]
            {
                "With the help of your team we design and implement automated testing processes in order to make sure exsisting functionalities will be left unchanged during the refactoring that will occur.",
                "We refactor the existing solution in a way that will isolate bounded contexts from the rest of the application without changing its current behavior.",
            }),
            new MigrationStep("Migration", new string[]
            {
                "We start migrating the now isolated bounded contexts to a set of microservices as defined in the second step of the process.",
                "Each of the resulting microservices is independently deployable and scalable using an automated pipeline.",
                "Each migration will reduces both the acquired technical debt and cognitive load on the development team, allowing a faster and more reliable development.",
            })
        }
    );

    private sealed record Intro(string Title, Type Icon, string Body);

    private sealed record Benefits(string Title, string Body, Benefit[] Items);
    private sealed record Benefit(string Title, string Description, Type Icon);

    private sealed record WhenToMigrate(string Title, string Body);

    private sealed record Migration(string Title, string Body, MigrationStep[] Steps);
    private sealed record MigrationStep(string Title, string[] Items);
}
