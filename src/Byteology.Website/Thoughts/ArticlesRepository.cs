namespace Byteology.Website.Thoughts;

public class ArticlesRepository
{
	private readonly LinkedList<ArticleMetadata> _data = new();
	private readonly Dictionary<string, LinkedListNode<ArticleMetadata>> _dict = new();

	public ArticlesRepository()
	{
		foreach (ArticleMetadata article in Articles.ArticlesDataSet.All)
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
