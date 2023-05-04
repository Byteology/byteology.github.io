namespace Byteology.Website.Thoughts.Articles;

public static class ArticlesDataSet
{
	public static IEnumerable<ArticleMetadata> All { get; } = new[]
	{
		Interviewing.Metadata
	};
}
