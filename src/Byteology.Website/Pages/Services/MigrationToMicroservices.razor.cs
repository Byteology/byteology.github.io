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
        IconSrc: "/images/microservices/icon.svg",
        Body: "In today’s disruptive web development world, microservices are receiving a lot of attention. Due to advances in cloud technology, the demand for microservices is increasing even more in scale. Unlike monolithic systems, microservices are designed to scale with changing market demands. Because of that modern enterprises are moving onto microservices from legacy monolithic systems."
    );
    private static Benefits getBenefitsSection() => new(
        Title: "Benefits of the Microservice Architecture",
        Body: "As the name suggests, microservices are micros, which break up a monolith app into a set of independent services. Unlike slow and heavy monolith architectures, microservices are faster to develop and deploy. Migrating from a monolithic application to microservices also enables you to optimize resources, enhance collaboration and streamline business processes.",
        Items: new Benefit[]
        {
            new Benefit("Agility", "Teams act within a small and well understood context, reducing cognitive complexity and shortening development cycle times.", "/images/microservices/icon.svg"),
            new Benefit("Domain Alignment", "Microservices align closely with their respective business domain allowing the use of ubiquitous language thus improving collaboration.", "/images/microservices/icon.svg"),
            new Benefit("Flexible Scaling", "Microservices allow each service to be independently scaled to meet demand for the application feature it supports.", "/images/microservices/icon.svg"),
            new Benefit("Easy Deployment", "Microservices enable continuous integration and continuous delivery, making it easy to try out new ideas and to roll back if something doesn’t work.", "/images/microservices/icon.svg"),
            new Benefit("Resilience", "Service independence increases an application’s resistance to failure.", "/images/microservices/icon.svg"),
            new Benefit("Technological Freedom", "Teams have the freedom to choose the best tool to solve their specific problems.", "/images/microservices/icon.svg"),
        }
    );
    private static WhenToMigrate getWhenToMigrateSection() => new(
        Title: "When to Migrate",
        Body: "Once you have made your mind to embrace microservices, the first question is – when should you move to microservices? The right time to migrate a monolithic app is when your organization is growing and is facing productivity and scaling issues or you start experiencing disruption in the communication between teams."
    );
    private static Migration getMigrationSection() => new(
        Title: "How to Migrate",
        Body: "The migration to microservice architecture is a complex process with many pitfalls. To avoid them we have spent years designing and refining a four-step strategy that helps businesses successfully migrate to microservices.",
        Steps: new MigrationStep[]
        {
            new MigrationStep("Process discovery", new string[]
            {
                "Organize a workshop with your domain experts and engineering team",
                "Map all the business processes that occur in your application",
                "Create a top-level document (process map) of what your application does and how it does it",
                "Establish a proper domain language and look for type instance homonyms so that domain experts and software engineers will be able to communicate fluently"
            }),
            new MigrationStep("Define bounded contexts", new string[]
            {
                "Use the process map to define entities, aggregates, services, and their bounded contexts",
                "Create a bounded context canvas for each context that will contain the definition of the context, its capabilities, responsibilities, policies, dependencies, and its ubiquitous language",
                "Identify proper microservices",
            }),
            new MigrationStep("Establish intra-service boundaries", new string[]
            {
                "Design and implement automated testing process in order to make sure exsisting functionalities will be left unchanged during the following refactoring",
                "Refactor the existing solution in a way that will isolate bounded contexts from the rest of the application without changing its current behavior",
            }),
            new MigrationStep("Migration", new string[]
            {
                "Migrate the isolated bounded contexts to microservices",
                "Each of the resulting microservices will be independently deployable and scalable using an automated pipeline",
                "Each microservice migration will reduce the acquired technical debt as well as the cognitive load on the development team, allowing faster and more reliable development",
            })
        }
    );

    private sealed record Intro(string Title, string IconSrc, string Body);

    private sealed record Benefits(string Title, string Body, Benefit[] Items);
    private sealed record Benefit(string Title, string Description, string IconSrc);

    private sealed record WhenToMigrate(string Title, string Body);

    private sealed record Migration(string Title, string Body, MigrationStep[] Steps);
    private sealed record MigrationStep(string Title, string[] Items);
}
