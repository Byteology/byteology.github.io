﻿namespace Byteology.Website.Pages.Services;

public partial class InterviewingAsAService : ComponentBase
{
    private readonly Intro _introModel;
    private readonly Section _thoroughnessModel;
    private readonly Skills _skillsModel;
    private readonly Section _expertiseLevelsModel;
    private readonly JobAdvert _jobAdvertModel;
    private readonly Budget _budgetModel;
    private readonly Section _motivationLetterModel;
    private readonly Section _applicationRoundModel;
    private readonly Section _interviewModel;
    private readonly Section _homeworkModel;
    private readonly Section _feedbackModel;
    private readonly Section _serviceModel;
    private readonly string _callToAction;

    public InterviewingAsAService()
    {
        _introModel = getIntroSection();
        _thoroughnessModel = getThoroughnessSection();
        _skillsModel = getSkillsSection();
        _expertiseLevelsModel = getExpertiseLevelsSection();
        _jobAdvertModel = getJobAdvertSection();
        _budgetModel = getBudgetSection();
        _motivationLetterModel = getMotivationLetterSection();
        _applicationRoundModel = getApplicationRoundSection();
        _interviewModel = getInterviewSection();
        _homeworkModel = getHomeworkSection();
        _feedbackModel = getFeedbackSection();
        _serviceModel = getServiceSection();
        _callToAction = "If you have any questions regarding interviewing - don't hasitate to contact us.";
    }

    private static Intro getIntroSection() => new(
        Title: "A Concise Guide to Conducting Technical Interviews",
        Icon: typeof(Icons.InterviewingAsAService.Icon),
        Body: new[] 
        {
            "Employees are the lifeblood of every company. They are the ones creating our products, providing our services and driving our growth and innovation. Because of this, it is of utmost importance to choose your employees with meticulous care. Unfortunately, this is a difficult process full of pitfalls. How do you craft a successful job advert? How do you identify a great candidate? How do you even know what “a great candidate” is?", 
            "We have spent over a decade thinking about these problems and are ready to share some of our findings in this guide.It is written with technical positions in mind but most of it applies to any job opening."
        }
    );

    private static Section getThoroughnessSection() => new(
        Title: "Thoroughness vs Brevity",
        Body: new[]
        {
            "The longer your interview process is - the higher chances you have to correctly determine if a potential applicant is a good fit. The problem is that you only have a limited amount of time and resources for conducting interviews.",
            "In other words - the longer you spend on a single application - the less applicants you’ll be able to interview, thus reducing your chances to find a good fit. On the other hand, if you don’t spend enough time - you won’t be able to identify potentially great candidates.",
            "Additionally, candidates usually don’t stop applying for other positions in different companies until they get a satisfactory job offer and if they receive one in the middle of your interview process they are very unlikely to finish it.",
            "Fortunately, the benefits of increasing the thoroughness of your process quickly hit diminishing returns and with careful planning and consideration you might be able to get to this point while simultaneously keeping the process quite brief.",
            "In the following sections we will go through all the steps of a typical interview process and talk about how to get the most out of them."
        }
    );

    private static Skills getSkillsSection() => new(
        Title: "Figuring Out What Skills You Are Looking For",
        Body: new string[]
        {
            "This step is arguably the most important one in the whole process yet it is oftentimes either completely ignored or it is being done idly by a single person for less than an hour.",
            "Having the skills you are looking for in a candidate listed and written down helps tremendously in the rest of the process. It helps you craft better adverts and interviews and it allows all of the people involved in the interviewing process to share the same vision.",
            "To identify the skills you are looking for, it helps to group them into two different categories."
        },
        Items: new SkillType[]
        {
            new SkillType(
                Title: "Technical Skills",
                Description: new string[]
                {
                    "Technical skills are the ones that are related to some kind of expertise regarding a certain piece of technology, software or specialized knowledge and are deeply rooted in a particular field of study. Usually they will be listed by your engineering team.",
                    "Beware that it is really tempting to list every piece of technology that your company uses. You should try to trim it down to the core skills that the potential new employee will practice on an everyday basis and those that are not acceptable to be learned during the job. People are willing to grow and are going to learn everything else in the process of doing their job."
                }, 
                Icon: typeof(Icons.InterviewingAsAService.TechnicalSkills)),
            new SkillType(
                Title: "Personal Skills",
                Description: new string[]
                {
                    "Personal skills are the ones that do not relate to a particular field of study. They might be willingness to teach or mentor others, the ability to organize a group of people, a certain way of tackling problems, dealing with interpersonal issues, working under pressure, etc.",
                    "Remember though that you are not looking for the perfect human being and include only those that are relevant to the particular position. You probably don’t need a team full of team leaders or people thinking outside of the box. In some cases you might not even want everybody to have strong analytical skills."
                },
                Icon: typeof(Icons.InterviewingAsAService.PersonalSkills)),
        }
    );

    private static Section getExpertiseLevelsSection() => new(
        Title: "About Expertise Levels",
        Body: new[]
        {
            "At this point you might have written something along the lines of *“The candidate must have at least 5 years of experience working in microservices architectures”*. Bear in mind that experience is only a small part of what builds up mastery and is not really a skill.",
            "Try to be a little bit more specific about what this kind experience means to you. For example, you might be looking for a particular level of autonomy when solving problems that your new employee will encounter: *“The candidate should be able to investigate and identify race conditions within a complex microservice architecture on their own”*.",
        }
    );

    private static JobAdvert getJobAdvertSection() => new(
        Title: "The Job Advert",
        Body: "Now that you know what you are looking for in potential candidates, it is time to start crafting your job advert. Thankfully, you are already half done at this point, but before we continue we need to understand a couple of things.",
        Sections: new[]
        {
            new Section(
                Title: "How Potential Candidates Interact With Job Adverts",
                new string[]
                {
                    "Everything in this section has a big *“in general”* asterisk attached to it. Additionally, this is the most opinionated part of this guide so take it with a grain of salt.",
                    "Potential candidates will rarely stumble upon your job advert by accident. Usually they are actively looking for their next job and are browsing through some kind of job adverts website. These websites often have very limited searching functionalities. In most cases these are a place of work, some vague industry category like *“IT services”* and maybe some predefined list of technologies or programming languages like *“.NET Core”*, *“C++”*, etc. As you can imagine, any combination of these filters yields hundreds, if not thousands of results.",
                    "Potential candidates have limited time as well, so they are not going to click through every single one in order to figure out if they are a good match before applying. Because of that they are playing a numbers game. Two of them actually.",
                    "The first one is *“Just by glancing at the title of an advert can I determine if the chances that I’m a good fit are above random”*. The titles of job adverts are usually some kind of skill requirement and the potential candidates will answer their question by figuring out if they have this particular skill. The problem is that the more vague the skill is - the less an affirmative answer raises the odds of being a good fit. For example, falling into the category of *“C#.NET Developer with SAP B1 experience for a marketplace”* means a lot more than falling into the category of *“Software Engineer”*.",
                    "Once a potential candidate has clicked on a job advert, comes their second question: *“How to determine if the time I’ll spend applying for this position will be worth the chance I have to be a good fit”*. This usually happens by checking the listed requirements. If they positively consider themselves to possess at least 80% of the listed skills - they will consider applying for the position. Take a note of that. It will help us a little bit later in a non-intuitive way.",
                    "Also bear in mind that if the candidate is not able to answer that question fast, they will most likely resort to going back to browsing adverts.",
                    "Only after the potential candidate has decided that it might be worth their while to apply for this position, they may or may not try to figure out if they’ll actually like working at it, but this is something quite subjective and really hard to determine upfront. This will be their last deciding factor before they take action."
                }),
             new Section(
                Title: "The Goals of an Advert",
                new string[]
                {
                    "Before starting to craft our job advert, we need to know one more thing: what makes an advert successful.",
                    "After publishing your job advert only a certain number of people will actually see or be interested in it and the higher this number is - the higher the chances that a great candidate will be among them. So the first goal of a successful job advert is to increase the number of people that will interact with it.",
                    "At some point candidates will start sending you applications. In most cases they will be way more than you have resources to interview people and you will have to resort to screening them by their application alone, which is not really effective for reasons we will describe a bit later.",
                    "Fortunately, a great tool for screening candidates is the job advert itself. If we craft it correctly it will automatically filter a lot of the people that are not a good fit. We have to be careful not to filter great candidates at the same time. So how do we do that?",
                }),
             new Section(
                Title: "Crafting The Job Advert",
                new string[]
                {
                    "Armed with this knowledge and the list of skills that you are looking for in a candidate, we are now ready to craft the perfect job advert.",
                    "Let’s start with its title. As we said earlier in order to attract the highest number of relevant candidates we must set the title to be the core requirement of the position written in the most specific way possible. You can also safely remove expertise levels like *“Junior/Senior”* because they are way too subjective and this makes them vague. A potential candidate’s idea of these levels may and will wildly differ from yours.",
                    "Now let’s continue with the list of skill requirements. Remember when we said that people will apply if they think they possess 80% of the required skills? This means that the bigger the list - the higher the chance candidates will apply while missing some of the core skills for the position and this might be a hard thing to catch on the application level. So your best option is to include only the skills you are not willing to compromise for and those that are not acceptable to be learned during the job. But don’t worry, you’ll test for the non-essentials during the interview.",
                    "Additionally you will want to write these skills as specific as possible for the same reason we wrote the title in this way. Also remember that people are objectively bad at evaluating themselves and the more vague the required skills are described - the worse the Dunning Kruger effect will be.",
                    "You may also want to ditch the *“required years of experience”* for a certain technology. Years of experience are only a small part of what builds up expertise and people know or at least feel it so they are inclined to ignore it. Also there are so many job adverts out there that require an unreasonable amount of years of experience that there are running jokes about it and people stopped paying attention. Instead you might ask for a particular level of autonomy when solving different kinds of problems. E.g. *“You should be able to investigate and identify race conditions within a complex microservice architecture on your own.”*",
                    "Don’t include any of the personal skills you are looking for either. People are even more terrible at self-evaluating their personal skills than their technical ones. We have never met a single person that said they are not a great problem solver or fast learner. If you include the personal skills potential candidates will mentally check them off when skimming through the list of requirements and this will make them more likely to apply even if they miss some of the important technical skills.",
                    "You might want to include the required personal skills in the job advert though. We will do that but we’ll cast it in another light. Instead of making potential candidates decide if they have a list of personal skills we would want them to dislike the position if they lack them. One way to do that is by describing how an example workday at that position might look like with a heavy emphasis on the personal skills required. For example instead of saying *“The perfect candidate must be a highly motivated self-learner”* you might say *“You will be spending a few hours a day researching new technologies and trends”*. This will discourage people lacking this particular skill from applying without them even knowing they have just self-evaluated it.",
                    "At this point you should be done crafting your advert. Everything else can be safely removed in order to keep it short. If someone is really interested in your company they will probably go to your website to check for more information. Making the advert unnecessarily large will only reduce the number of people who will actually read it."
                }),
        }
    );

    private Budget getBudgetSection() => new(
        Title: "Should you state your budget for the position?",
        Body: "There is no one right answer to this question so let’s think a little bit about what are the pros and the cons of stating your budget upfront.",
        Pros: new[]
        {
            "It statistically increases the number of people that apply for the position (which might or might not be a good thing depending on how many candidates you are expecting).",
            "It will also automatically filter candidates that are out of your price range. Otherwise the budget talks are happening after the interview rounds which means that you might have wasted precious resources interviewing a candidate that you can’t hire because of budget reasons instead of interviewing another candidate.",
            "Discussing the expected salary with a candidate is more or less a kind of bargaining which might make them feel like you as an employer do not share their best interest which is not a great way to start a relationship."
        },
        Cons: new[]
        {
            "If your job offer is in the lower half of the listed budget, the candidate may feel cheated.",
            "You are inevitably going to pay more than you would have otherwise but to be fair you can think of this money as being spent for the better well being of your new employee.",
            "You are giving insights of your budget to your direct competitors which might not be a good idea if you think there is somebody who is actively looking to outbid you."
        });

    private static Section getMotivationLetterSection() => new(
        Title: "Motivation letters",
        Body: new[]
        {
            "Motivation letters are weird things. They increase the thoroughness of your interview process but in return they pre-screen a lot of candidates. This might seem to be of great help if you are receiving way too many applications than you can handle but it might not be an accurate screening. They make the process of applying harder which filters candidates based on motivation to apply for this exact job or sometimes by desperation to get any job at all.",
            "Additionally, you will want to actually read and evaluate these and this costs additional resources while filtering candidates on what is basically an essay for a job that probably has nothing to do with writing.",
            "One great use for motivation letters though, is for intern positions or positions for which candidates are not required to have any previous experience. In these situations it might be really difficult to distinguish between candidates and their motivation letters might be the only tool you have available."
        }
    );

    private static Section getApplicationRoundSection() => new(
        Title: "The Application Round",
        Body: new[]
        {
            "At this point hopefully you have received more applications than people you can interview. Now you may wonder how to filter them.",
            "It might be tempting to pick the best-looking and the most refined CVs and it is definitely a tell about certain personal skills but bear in mind that you are not looking for the person who is able to craft the best CV. ",
            "The only other thing you can do is keep statistics. You should keep track which universities and previous employers yielded successful interviews in the past. Maybe a certain style of writing, certain kind of certifications, years of experience or something entirely different.",
            "That doesn’t mean you should give a chance to anyone that doesn’t fit your statistics but it might help you when you are hard-pressed to choose which applicant to interview.",
            "Basically you’ll create some kind of system to help you order applications but this is the part of the process in which you are trying to make a decision having only a minimum amount of information. This is why keeping statistics might be your best bet in the long term.",
        }
    );

    private static Section getInterviewSection() => new(
        Title: "The Interview",
        Body: new[]
        {
            "The actual interview is arguably the most important part of the whole process because during it you’ll be gathering the most information about the candidates that will help you make an informed decision. But remember that you have only so much time to gather that information. Because of that you need to carefully prepare beforehand.",
            "Take a look at what are the skills that you are looking for in a candidate and focus your efforts on them. Carefully craft appropriate conversations beforehand. We used the word *“conversation”* instead of *“questions”* on purpose. The interview is not a trivia exam. You might ask a candidate *“Can you tell me about the SOLID principles”* but that usually doesn’t help you understand if the candidate has the required skills to apply them in practice. Instead you might ask them for their opinion on the controversy around the dependency inversion principle. Maybe they will try to defend it, maybe they will try to prove that it is too extreme, maybe they will hold an opinion that it is more of a guideline than an actual rule. Either way you’ll understand a lot more about the interviewee than checking if they have read the Wikipedia article or have been asked the same question at another interview.",
            "This way of conducting the interview also helps the candidate feel more comfortable because they don’t follow the exam scenario. You should understand that the interviewee is in a bad spot. They might be nervous, worried or outright scared. This might happen because getting this job is really important to them, because there are five people who are conducting this interview (please keep this number to a minimum) or they just might have trouble keeping calm when they are asked something they don’t know.",
            "You should always be aware of how nervous the interviewee is at any moment and try to calm them down. There are many ways to do so. One of them is to not acknowledge that they are nervous and just ask them a couple of related to the current topic questions you know they will answer. If you fail to do so, continuing the interview with a nervous candidate will not tell you anything about their skills but how well they can work under pressure which is usually not a requirement for their job.",
            "Remember that the interview is a two-way street. This is what “inter” means. Leave enough time to let the person ask you questions and to pick their own topics. In fact this way you’ll also understand a little bit more about them.",
        }
    );

    private static Section getHomeworkSection() => new(
        Title: "What About Homework Assignments",
        Body: new[]
        {
            "Homework assignments are a great way to increase the thoroughness of the interview process while keeping it brief (for you at least) although they come with a different load of problems.",
            "It is hard to craft a homework assignment that will properly reflect the skills you are looking for. You might think this is a one time deal but you’ll be surprised how fast the assignment and the proper solutions leak to the public. Additionally different positions require different assignments.",
            "You can’t be sure that the solution comes from the assignee. Because of that you should at least schedule a call to talk with them about the solution. This combined with the actual grading of the solution will take time that you might want to spend somewhere else in the process.",
            "Additionally the whole homework assignment, grading and the follow-up interview may take weeks and during this time the candidate might receive a job offer from another company making them very unlikely to finish your interview process.",
        }
    );

    private static Section getFeedbackSection() => new(
        Title: "Feedback",
        Body: new[]
        {
            "After every interview candidates may ask for feedback on how they have done. But regardless of whether they did it or not you should provide it. This serves a few really important purposes.",
            "Verbalizing the feedback helps you better understand what you are looking for and helps you craft better interviews in the future.",
            "It helps build trust and transparency between you and the candidate. That’s a great thing to do even if you don’t plan to hire them. We have had many successful candidates referred to us by people we haven’t hired.",
            "It helps the candidates grow and become better experts in the future and as interviewers we have a responsibility to try and help these people even if they are not the right fit for our company right now.",
            "Just remember that 30 minutes after the interview, you’ll forget about 70% of the feedback that you have to give. You don’t need to wait for a hiring decision before that. And on that note when a hiring decision is made, take a minute and inform the candidate regardless of the decision itself. They will appreciate it tremendously and will probably spread a good word.",
        }
    );

    private static Section getServiceSection() => new(
        Title: "Interviewing as a Service",
        Body: new[]
        {
            "If you have come this far you probably understand that interviewing is a really important but complex process that requires many years of deliberate practice and careful preparation that takes a lot of time.",
            "Fortunately our team can help you with that by helping you during every step of the process or by just conducting interviews on your behalf so you can focus on your core business while resting assured you’ll hire great people that will help you grow.",
        }
    );

    private sealed record Intro(string Title, Type Icon, string[] Body);
    private sealed record Section(string Title, string[] Body);

    private sealed record Skills(string Title, string[] Body, SkillType[] Items);
    private sealed record SkillType(string Title, string[] Description, Type Icon);

    private sealed record JobAdvert(string Title, string Body, Section[] Sections);

    private sealed record Budget(string Title, string Body, string[] Pros, string[] Cons);

}
