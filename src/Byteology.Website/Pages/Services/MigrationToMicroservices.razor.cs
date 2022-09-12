namespace Byteology.Website.Pages.Services;

public partial class MigrationToMicroservices
{
    private readonly Model _model;

    public MigrationToMicroservices()
    {
        _model = new Model(new Timeline[]
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
        });
    }

    private sealed record Model(Timeline[] Process);
    private sealed record Timeline(string Title, string[] Items);
}
