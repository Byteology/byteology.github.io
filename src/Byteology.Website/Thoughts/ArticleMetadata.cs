namespace Byteology.Website.Thoughts;

public record ArticleMetadata(
	string Handle,
	ArticleCategory Category,
	string Title,
	string Intro,
	string[] Keywords);
