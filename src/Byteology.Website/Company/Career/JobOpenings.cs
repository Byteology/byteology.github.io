namespace Byteology.Website.Company.Career;

using Byteology.Website.Company.Career.Openings;

public static class JobOpenings
{
	public static JobOpening DotNetEngineer { get; } =
		new(
			Id: "dotnet-engineer",
			Title: ".NET Engineer",
			Intro: "You'll be working together with other team members on our clients' and our own products. We are striving to deliver amazing quality so be prepared for a lot of code reviews, programming and architectural discussion and code analysis.",
			Icon: typeof(Icons.GearsIcon),
			SalaryInEuro: new (3000, 3600),
			DetailsComponent: typeof(DotNetEngineer)
		);

	public static JobOpening InternDotNetEngineer { get; } =
		new(
		    Id: "intern-dotnet-engineer",
		    Title: "Intern .NET Engineer",
		    Intro: "You'll be assigned a personal mentor with a long history of working in the industry. Together you will work on both our clients' and our own products. Our goal is to kickstart your professional development and help you become the best software engineer you can be.",
		    Icon: typeof(Icons.GearsIcon),
		    SalaryInEuro: new (1600, 2000),
		    DetailsComponent: typeof(InternDotNetEngineer)
		   );

	public static JobOpening[] Current { get; } = new JobOpening[] { };
}
