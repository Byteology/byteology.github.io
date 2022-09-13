namespace Byteology.Website.Pages.Services;

public partial class MigrationToMicroservices
{
    private readonly Model _model;

    public MigrationToMicroservices()
    {
        _model = new Model(
            Title: "Migration to Microservices",
            Intro: "We have researched and designed strategies and processes that help businesses successfully migrate to microservices.",
            Benefits: new Benefit[]
            {
                new Benefit("Agility", "Microservices foster an organization of small, independent teams that take ownership of their services. Teams act within a small and well understood context, and are empowered to work more independently and more quickly. This shortens development cycle times. You benefit significantly from the aggregate throughput of the organization."),
                new Benefit("Flexible Scaling", "Microservices allow each service to be independently scaled to meet demand for the application feature it supports. This enables teams to right-size infrastructure needs, accurately measure the cost of a feature, and maintain availability if a service experiences a spike in demand."),
                new Benefit("Easy Deployment", "Microservices enable continuous integration and continuous delivery, making it easy to try out new ideas and to roll back if something doesn’t work. The low cost of failure enables experimentation, makes it easier to update code, and accelerates time-to-market for new features."),
                new Benefit("Technological Freedom", "Microservices architectures don’t follow a “one size fits all” approach. Teams have the freedom to choose the best tool to solve their specific problems. As a consequence, teams building microservices can choose the best tool for each job."),
                new Benefit("Reusable Code", "Dividing software into small, well-defined modules enables teams to use functions for multiple purposes. A service written for a certain function can be used as a building block for another feature. This allows an application to bootstrap off itself, as developers can create new capabilities without writing code from scratch."),
                new Benefit("Resilience", "Service independence increases an application’s resistance to failure. In a monolithic architecture, if a single component fails, it can cause the entire application to fail. With microservices, applications handle total service failure by degrading functionality and not crashing the entire application."),
            },
            Process: new Timeline[]
            {
                new Timeline("Process discovery", new string[]
                {
                    "Organize a workshop with your domain experts and engineering team",
                    "Map all the business processes that occur in your application",
                    "Create a top-level document (process map) of what your application does and how it does it",
                    "Establish a proper domain language and look for type instance homonyms so that domain experts and software engineers will be able to communicate fluently"
                }),
                new Timeline("Define bounded contexts", new string[]
                {
                    "Use the process map to define entities, aggregates, services, and their bounded contexts",
                    "Create a bounded context canvas for each context that will contain the definition of the context, its capabilities, responsibilities, policies, dependencies, and its ubiquitous language",
                    "Identify proper microservices",
                }),
                new Timeline("Establish intra-service boundaries", new string[]
                {
                    "Design and implement automated testing process in order to make sure exsisting functionalities will be left unchanged during the following refactoring",
                    "Refactor the existing solution in a way that will isolate bounded contexts from the rest of the application without changing its current behavior",
                }),
                new Timeline("Migration", new string[]
                {
                    "Migrate the isolated bounded contexts to microservices",
                    "Each of the resulting microservices will be independently deployable and scalable using an automated pipeline",
                    "Each microservice migration will reduce the acquired technical debt as well as the cognitive load on the development team, allowing faster and more reliable development",
                })
            }
        );
    }

    private sealed record Model(string Title, string Intro, Benefit[] Benefits, Timeline[] Process);
    private sealed record Benefit(string Title, string Description);
    private sealed record Timeline(string Title, string[] Items);
}
