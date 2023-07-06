namespace Byteology.Website.Thoughts;

using System.Collections.Generic;
using Byteology.Website.Shared.MarkdownRendering;

public class ArticlesRepository : PapersRepository
{
	public ArticlesRepository() : base(getPapersMetadata(), "thoughts/", getArticlesNamespace(), getLegacyHandles()) { }

	private static PaperMetadata[] getPapersMetadata()
	{
		PaperMetadata[] result =
			GetPaperMetadataFromEmbeddedJson(typeof(ArticlesRepository).Assembly, "Thoughts.Articles.article-list.json");

		return result;
	}

	private static IEnumerable<(string legacyHandle, string newHandle)>? getLegacyHandles()
	{
		yield return new("interviewing", "recruitment-guide-part-1");
	}

	private static string getArticlesNamespace()
	{
		return $"{typeof(ArticlesRepository).Namespace}.Articles";
	}
}