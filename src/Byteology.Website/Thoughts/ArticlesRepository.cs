namespace Byteology.Website.Thoughts;

using System.Reflection;
using System.Text.Json;

public class ArticlesRepository
{
	private readonly LinkedList<ArticleMetadata> _data = new();
	private readonly Dictionary<string, LinkedListNode<ArticleMetadata>> _dict = new();

	public ArticlesRepository()
	{
		Assembly assembly = typeof(ArticlesRepository).Assembly;
		string assemblyName = assembly.GetName().Name!;

		string path = $"{assemblyName}.Thoughts.Articles";

		using Stream articleListStream = assembly.GetManifestResourceStream($"{path}.ArticleList.json")!;
		using StreamReader articleListReader = new(articleListStream);
		string rawArticleList = articleListReader.ReadToEnd();
		ArticleMetadata[] articleList = JsonSerializer.Deserialize<ArticleMetadata[]>(rawArticleList, new JsonSerializerOptions(JsonSerializerDefaults.Web))!;

		foreach (ArticleMetadata article in articleList)
		{
			LinkedListNode<ArticleMetadata> node = _data.AddLast(article);
			_dict.Add(article.Handle, node);
		}
	}

	public IEnumerable<ArticleMetadata> GetAll() => _data;

	public ArticleMetadata? Get(string handle)
	{
		_dict.TryGetValue(handle, out LinkedListNode<ArticleMetadata>? result);
		return result?.Value;
	}

	public ArticleMetadata? GetNext(string handle)
	{
		_dict.TryGetValue(handle, out LinkedListNode<ArticleMetadata>? node);
		return node?.Next?.Value;
	}

	public ArticleMetadata? GetPrevious(string handle)
	{
		_dict.TryGetValue(handle, out LinkedListNode<ArticleMetadata>? node);
		return node?.Previous?.Value;
	}
}
