namespace Byteology.Website.Thoughts;

using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

public class ArticlesRepository
{
	private readonly LinkedList<ArticleMetadata> _data = new();
	private readonly Dictionary<string, LinkedListNode<ArticleMetadata>> _dict = new();

	public ArticlesRepository()
	{
		Assembly assembly = typeof(ArticlesRepository).Assembly;
		string assemblyName = assembly.GetName().Name!;

		string path = $"{assemblyName}.Thoughts.Articles";

		using Stream articleListStream = assembly.GetManifestResourceStream($"{path}.article-list.json")!;
		using StreamReader articleListReader = new(articleListStream);
		string rawArticleList = articleListReader.ReadToEnd();

		JsonSerializerOptions serializerOptions = new(JsonSerializerDefaults.Web);
		serializerOptions.Converters.Add(new JsonStringEnumConverter());
		ArticleMetadata[] articleList = JsonSerializer.Deserialize<ArticleMetadata[]>(rawArticleList, serializerOptions)!;

		foreach (ArticleMetadata article in articleList.Reverse())
		{
			LinkedListNode<ArticleMetadata> node = _data.AddLast(article);
			bool success = _dict.TryAdd(article.Handle, node);
			if (!success)
				_data.RemoveLast();
		}
	}

	public IEnumerable<ArticleMetadata> GetAll() => _data.Reverse();

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
