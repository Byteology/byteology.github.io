namespace Byteology.Website.Thoughts;

public record ArticleInfo(
	ArticleCategory Category,
	string Title,
	string Intro,
	string Id,
	Type ArticleComponent,
	string[] Keywords);
