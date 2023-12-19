namespace Byteology.Website.Thoughts;

using System.Collections.Generic;
using Byteology.Website.Shared.MarkdownRendering;

public class ArticlesRepository : PapersRepository
{
	public ArticlesRepository() : base(
			paperList: getPapersMetadata(),
			urlPrefix: "thoughts",
			papersNamespace: getArticlesNamespace(),
			defaultIcon: typeof(Icons.BooksIcon),
			legacyHandles: getLegacyHandles())
	{ }

	private static PaperMetadata[] getPapersMetadata()
	{
		PaperMetadata[] result =
			GetPaperMetadataFromEmbeddedJson(typeof(ArticlesRepository).Assembly, "Thoughts.Data.article-list.json");

		return result;
	}

	private static IEnumerable<(string legacyHandle, string newHandle)>? getLegacyHandles()
	{
		yield return new("interviewing", "strategic-recruitment-part-1");
		yield return new("recruitment-guide-part-1", "strategic-recruitment-part-1");
		yield return new("recruitment-guide-part-2", "strategic-recruitment-part-2");
		yield return new("recruitment-guide-part-3", "strategic-recruitment-part-3");
		yield return new("recruitment-guide-part-4", "strategic-recruitment-part-4");
		yield return new("recruitment-guide-part-5", "strategic-recruitment-part-5");
		yield return new("recruitment-guide-part-6", "strategic-recruitment-part-6");
	}

	private static string getArticlesNamespace()
	{
		return $"{typeof(ArticlesRepository).Namespace}.Data";
	}
}