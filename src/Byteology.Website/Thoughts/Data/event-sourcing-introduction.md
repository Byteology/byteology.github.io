# Introduction to Event Sourcing - Empowering Data Processing and System Evolution
Most applications work with data and the typical way to do it is by maintaining its current state and updating it as time passes. Unfortunately, this way of interacting with data comes with a lot of drawbacks.

---

## Limitations of CRUD-based Systems
In a typical CRUD based application the data is being processed by reading it from a store, making some modifications to it and then pushing them back to the store, often by using transactions to lock the data.

Currently, the CRUD approach is the most used and well-known one regarding data persistence but unfortunately it has some limitations:

- CRUD systems perform update operations directly against a data store, which can slow down performance and responsiveness, and limit scalability, due to the processing overhead it requires.
- In a collaborative domain with many concurrent users, data update conflicts are more likely because the update operations take place on a single item of data.
- Unless there's an additional auditing mechanism that records the details of each operation in a separate log, history is lost.
- Debugging a production issue requires data from both the data store and the audit log to be interpreted and used together to form a replay.

---

## The Solution
Instead of storing just the current state of the domain data, event sourced systems use an append-only store to record the full series of actions taken on that data as a sequence of events.

This simplifies tasks in complex domains, by avoiding the need to synchronize the data model and the business domain, while improving performance, scalability and responsiveness. It also provides consistency for transactional data and maintains full audit trails and history. Following is a list of some of the benefits that event sourcing provides:

#### <b-icon name="CheckboxList"></b-icon> Audit Trail
The append-only storage of events provides an audit trail that can be used to monitor actions taken against a data store, regenerate the current state as materialized views or projections by replaying the events at any time, and assist in testing and debugging the system.

In addition, the requirement to use compensating events to cancel changes provides a history of changes that were reversed, which wouldn't be the case if the model simply stored the current state.

The list of events can also be used to analyze application performance and detect user behavior trends, or to obtain other useful business information.

#### <b-icon name="DomainAlignment"></b-icon>Domain Alignment
Events typically have meaning for a domain expert, whereas object-relational impedance mismatch can make complex database tables hard to understand. Tables are artificial constructs that represent the current state of the system, not the events that occurred.

Using events as the main carriers of data allows the use of ubiquitous language between domain experts and software engineers thus improving collaboration.

#### <b-icon name="TimeChart"></b-icon>Temporal Querying
We can determine the application state at any point in time. Notionally we do this by starting with a blank state and rerunning the events up to a particular time or event. We can take this further by considering multiple time-lines (analogous to branching in a version control system). This allows us to get a full overview of how the application’s data evolved and query it at any point in the past.

#### <b-icon name="MagnifiedQuestion"></b-icon>What-if Analysis
With event sourcing it is possible to change how certain events are being handled and then simulate how this would have influenced the data. This method is called “what-if analysis” and is a great way to make data driven decisions.

#### <b-icon name="Replay"></b-icon>Event Replay
If we find a past event was handled incorrectly due to a bug or some other failure, we can compute the consequences by reversing it and later events and then replaying them again.

This way it is sometimes possible to fix past issues without having to worry about impacting the application’s data.

The same technique can handle events received in the wrong sequence - a common problem with systems that communicate with asynchronous messaging.

#### <b-icon name="Decoupling"></b-icon>Decoupling
The event store raises events, and tasks perform operations in response to those events. This decoupling of the tasks from the events provides flexibility and extensibility. Tasks know about the type of event and the event data, but not about the operation that triggered the event. In addition, multiple tasks can handle each event.

This enables easy integration with other services and systems that only have to listen for events raised by the event store.

#### <b-icon name="History"></b-icon>Retroactive Development
We can discard the application state completely and rebuild it by re-running the events from the event log on an empty application. This way you can introduce different or additional processing of some events.

A common example for that is an e-commerce website. At some point in the application lifecycle you might want to introduce a functionality that suggests items to your customers based on what they have removed from their shopping carts right before checking out.

With a traditional CRUD system you will start recording what gets removed from carts and then feed that data to the new functionality. The problem with that is all changes to a cart before the implementation are unknown.

In contrast, event sourcing allows you to replay all events on shopping carts that ever occurred and use them to build a new model for the suggestion functionality, allowing it to work as if it was collecting data from day one.

#### <b-icon name="Speed"></b-icon>High Performance
Events are immutable and can be stored using an append-only operation. This way the user interface or any other process that initiated an event can continue, and tasks that handle the events can run in the background.

Additionally, data is retrieved from specialized projections that are optimized for performance.

All of this, combined with the fact that there's no contention during the processing of transactions, can vastly improve performance and scalability for applications, especially for the presentation level or user interface.

---

## When to Use Event Sourcing
Event sourcing is not a silver bullet, though. There are situations in which you might want to actively avoid it.

### Use When
- you want to capture intent, purpose, or reason in the data.
- it's vital to minimize or completely avoid the occurrence of conflicting updates to data.
- you want to record events that occur, and be able to replay them to restore the state of a system, roll back changes, or keep a history and audit log.
- using events is a natural feature of the operation of the application, and requires little additional development or implementation effort.
- you need to decouple the process of inputting or updating data from the tasks required to apply these actions. This might be to improve UI performance, or to distribute events to other listeners that take action when the events occur.
- you want flexibility to be able to change the format of materialized models and entity data if requirements change, or—when used in conjunction with CQRS—you need to adapt a read model or the views that expose the data.
- used in conjunction with CQRS, eventual consistency is acceptable while a read model is updated, or the performance impact of rehydrating entities and data from an event stream is acceptable.

{.negative}
### Avoid Using On
{.negative}
- non-domain systems that naturally work well with traditional CRUD data management mechanisms.
- systems where consistency and real-time updates to the views of the data are required.
- systems where audit trails, history, and capabilities to roll back and replay actions are not required.
-systems where there's only a very low occurrence of conflicting updates to the underlying data. For example, systems that predominantly add data rather than updating it.
