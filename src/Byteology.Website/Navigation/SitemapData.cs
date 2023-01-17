namespace Byteology.Website.Navigation;

using Byteology.Website.Company;
using Byteology.Website.Inquiry;
using Byteology.Website.Services;

public static class SitemapData
{
	public static Section[] Sections { get; }
	public static Link CallToAction { get; }
	public static Link PrivacyPolicy { get; }

	static SitemapData()
	{
		Sections = new Section[]
		{
			new Section("Company", RouteDetector.Match<HomePage>(), new Link[]
			{
				new Link("Home", RouteDetector.Match<HomePage>()),
				new Link("Mission", RouteDetector.Match<MissionPage>()),
				new Link("Careers", RouteDetector.Match<CareersPage>()),
				new Link("Contacts", RouteDetector.Match<ContactsPage>())
			}),
			new Section("Services", RouteDetector.Match<ServiceListPage>(), new Link[]
			{
				new Link("Software Development", RouteDetector.Match<SoftwareDevelopmentPage>()),
				new Link("Research & PoC",RouteDetector.Match<ResearchAndPocPage>()),
				new Link("Migration to Microservices", RouteDetector.Match<MigrationToMicroservicesPage>()),
				new Link("Event Sourcing", RouteDetector.Match<EventSourcingPage>()),
				new Link("Education & Training", RouteDetector.Match<EducationAndTrainingPage>()),
				new Link("Interviewing as a Service", RouteDetector.Match<InterviewingAsAServicePage>()),
			}),
		};

		CallToAction = new Link("Contact us", RouteDetector.Match<ContactsPage>());
		PrivacyPolicy = new Link("Privacy policy", RouteDetector.Match<PrivacyPage>());
	}

	public record Section(string Title, string Url, Link[] Items)
	{
		public bool IsRoot() => Url == RouteDetector.Match<HomePage>();
	}

	public record Link(string Title, string Url)
	{
		public bool IsHome() => Url == RouteDetector.Match<HomePage>();
		public bool IsCallToAction() => Url == CallToAction.Url;
	}
}
