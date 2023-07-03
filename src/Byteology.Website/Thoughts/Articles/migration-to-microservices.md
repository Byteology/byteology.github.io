# Migration to Microservices - 4-step Strategy

In today's disruptive web development world, microservices are receiving a lot of attention. Unlike monolithic systems, microservices are designed to scale with changing market demands. Because of that, modern enterprises are moving their legacy monolithic systems to microservices architecture.

## Benefits of the Microservice Architecture

As the name suggests, microservices are small units that break up a monolithic application into a set of independent services. Unlike slow and heavy monolithic applications, microservices are faster to develop and deploy. Migrating from a monolithic architecture to a microservice one provides a lot of benefits, most important of which are as follows:


### <b-icon name="RaindropIcon"/> Simplicity
Teams act within a small and well understood context, reducing cognitive complexity and shortening development cycle times.

### <b-icon name="DomainAlignmentIcon"/>  Domain Alignment
Microservices align closely with their respective business domains, allowing the use of ubiquitous language and thus improving collaboration.

### <b-icon name="ScalingIcon"/>  Flexible Scaling
Microservices allow each service to be independently scaled to meet demand for the application feature it supports.

### <b-icon name="DeploymentIcon"/>  Easy Deployment
Microservices enable continuous integration and continuous delivery, making it easy to try out new ideas and to roll back if something doesn't work.

### <b-icon name="DominosIcon"/>  Resilience
Service independence increases an application's resistance to failure.

### <b-icon name="DirectionsIcon"/>  Freedom
Teams have the freedom to choose the best tool to solve their specific problems.

## When to Migrate
Once you have made your mind to embrace microservices, the first question is - when should you make your move? Usually the right time to migrate a monolithic application is when your organization is growing and is facing productivity and scaling issues or when you start experiencing disruption in the communication between teams.

## How to Migrate
The migration to microservice architecture is a complex process with many pitfalls. To avoid them we have spent
years designing and refining a four-step strategy that helps businesses successfully migrate to microservices.

### Step 1 - Process Discovery
1. We organize a workshop with your domain experts and engineering team.
1. Together we map all the business processes that occur in your application.
1. As an output we create a top-level document (process map) of what your application does and how it does it.
1. Additionally, we establish a proper domain language and look for type instance homonyms so that domain experts and software engineers will be able to communicate fluently.

### Step 2 - Defining Bounded Contexts
1. We use the process map to define entities, aggregates, services, and their bounded contexts.
1. This gets detailed in a bounded context canvas for each context. It contains the definition of the context, its capabilities, responsibilities, policies, dependencies, and its ubiquitous language.
1. As an output we create a top-level document (process map) of what your application does and how it does it.
1. Using the bounded context canvases we identify proper microservices. Usually they align with the contexts themselves but can range in size anywhere between a single aggregate and a whole bounded context.

### Step 3 - Establishing Service Boundaries
1. With the help of your team we design and implement regression testing processes and suites in order to make sure existing functionalities will be left unchanged during the refactoring that will occur.
1. We refactor the existing solution in a way that will isolate bounded contexts from the rest of the application without changing its current behavior.

### Step 4 - Migration
1. We start migrating the now isolated bounded contexts to a set of microservices as defined in the second step of the process.
1. Each of the resulting microservices is independently deployable and scalable using an automated pipeline.
1. Each migration reduces both the acquired technical debt and cognitive load on the development team, allowing a faster and more reliable development.