# Core Skills for Software Development
Software development is not a single skill. Instead it is a complex process that spans many fields of study. In this article we’ll try to identify them and share some of our thoughts on them.

--- 

## Domain Design

Every piece of software ultimately solves some kind of business problem that forms a domain (sometimes called problem space). Stripping down all of the abstractions and technologies that an application employs, at its core we are left with a domain model.

The closer this model aligns with the actual domain - the easier it becomes for the software to evolve with the business itself. This is the main reason why domain driven design gained so much traction in recent years and this is why we consider it to be one of the most valuable skills in software development.

---

## Communication
Long gone are the days when applications were built by a single person. Nowadays a group of 5 people is considered a micro team. This is a good thing but it creates a new set of problems.

For a team to be able to deliver a successful product, at any given time all of the members should be on the same page regarding what they are doing and how they are doing it. Bear in mind that when a team grows, the number of communication channels grows at a quadratic rate.

E.g. a team of 6 people will have at least 15 communication channels excluding the inter-team ones.

This creates a lot of additional failure points as well as a huge overhead which at some point may cause a productivity drop.

Communication is a broad term that involves planning, meeting discipline, knowledge sharing, use of ubiquitous language, mediation, etc. Each of these is a skill on its own that plays a huge role in modern software development.

We’ve spent years researching all of them and coming up and iterating on tools and processes that help us to be as efficient as possible.

---

## Programming and Architecture
Once you have figured out your domain model and have established good inter- and intra- team communication, it is time to actually build your software.

There isn’t a lot that hasn’t been already said a thousand times. Everyone is preaching a set of paradigms, principles, patterns or something else. All of these are probably correct but truth be told, these are all just tools in our belt and no single tool will make us excellent builders.

As software engineers our job is to be aware of them and have the ability to understand when and how to use them. This ties neatly to the last skill we’ll talk about here.

---

## Thinking deeply about simple things
When developing, we are making a lot of decisions based on either best practices knowledge or on previous experience.

This might seem great but it is the definition of *"programming by coincidence"*. It shows our tendencies to stop questioning things that seem obvious and leads to situations like these:

- ""This is considered best practice so we can just implement it real quick and get on with it.""
- ""We encountered this issue before and solved it by doing X so let’s do that again.""
- ""It is considered great to have a daily meeting every morning. Let's start doing stand-up meetings.""

While these decisions may actually be the right ones, the way we think about them ignores some aspects of the situation which might make them invalid.

- ""This solution is considered best practice but is it actually solving our problem correctly or is it designed for something entirely different or maybe something that only looks the same but it is not at its core? Why is it accepted as a best practice in the first place?""
- ""The last time we solved the issue, did we actually solve it or did we just mitigate the symptoms? What is causing the issue in the first place? Why did our previous solution work? Why has the issue resurfaced again?""

- ""What is the problem that daily meetings solve? Do we experience it? Is this the best tool to solve our problems? What does “the morning” mean for our distributed team? Are we creating another issue by fracturing the focus hours of our engineers? Aren’t we already tracking our progress in some other way?""

Simply put, to think deeply about simple things means to constantly question them even when the solution seems obvious. Usually the first solution you think of that looks sensible and is easy to implement is a terrible and inefficient idea that will cause suffering in the long term.

The good news is that because this is valid even outside the software engineering field, we can practice it a lot until it becomes a second nature to us.

---

By no means this was an extensive list of skills. Additionally, each of them is a whole field of study on its own.

We’ll continue writing about them in other articles but in the meantime don’t hesitate to ask us anything and we’ll be happy to share our findings or help you build your dream software.
