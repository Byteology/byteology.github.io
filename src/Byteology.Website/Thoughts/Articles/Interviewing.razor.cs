namespace Byteology.Website.Thoughts.Articles;

public partial class Interviewing : ComponentBase
{
	public static ArticleInfo Info { get; } = new(
		Category: ArticleCategory.Recruitment,
		Title: "A Concise Guide to Conducting Technical Interviews",
		Intro: "How do you craft a successful job advert? How do you identify a great candidate? How do you even know what a “great candidate” is? We have spent over a decade thinking about these problems and are ready to share some of our findings in this guide.",
		Id: "interviewing",
		ArticleComponent: typeof(Interviewing),
		Keywords: new string[] { "interviewing", "hiring", "interviewing as a service", "iaas", "guide", "job application", "job adverts" }
	);
}