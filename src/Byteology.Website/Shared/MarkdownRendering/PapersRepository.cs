namespace Byteology.Website.Shared.MarkdownRendering;

using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

public abstract class PapersRepository
{
	public static PaperMetadata[] GetPaperMetadataFromEmbeddedJson(Assembly assembly, string resourceName)
	{
		string assemblyName = assembly.GetName().Name!;
		using Stream paperListStream = assembly.GetManifestResourceStream($"{assemblyName}.{resourceName}")!;

		using StreamReader paperListReader = new(paperListStream);
		string rawPaperList = paperListReader.ReadToEnd();

		JsonSerializerOptions serializerOptions = new(JsonSerializerDefaults.Web);
		serializerOptions.Converters.Add(new JsonStringEnumConverter());
		PaperMetadata[] paperList = JsonSerializer.Deserialize<PaperMetadata[]>(rawPaperList, serializerOptions)!;
		return paperList;
	}

	private readonly LinkedList<PaperMetadata> _data = new();
	private readonly Dictionary<string, LinkedListNode<PaperMetadata>> _dict = new();
	private readonly Dictionary<string, List<string>> _legacyHandles = new();

	private readonly string _urlPrefix;
	private readonly string _papersNamespace;


	protected PapersRepository(
		PaperMetadata[] paperList,
		string urlPrefix,
		string papersNamespace,
		IEnumerable<(string legacyHandle, string newHandle)>? legacyHandles = null)
	{
		_urlPrefix = urlPrefix.EndsWith('/') ? urlPrefix : urlPrefix + "/";
		_papersNamespace = papersNamespace;

		if (legacyHandles != null)
		{
			foreach ((string legacyHandle, string newHandle) legacyHandle in legacyHandles)
			{
				if (!_legacyHandles.ContainsKey(legacyHandle.newHandle.ToLower()))
					_legacyHandles.Add(legacyHandle.newHandle.ToLower(), new List<string>());

				_legacyHandles[legacyHandle.newHandle.ToLower()].Add(legacyHandle.legacyHandle.ToLower());
			}
		}

		foreach (PaperMetadata paper in paperList.Reverse().Where(x => !x.Inactive))
		{
			LinkedListNode<PaperMetadata> node = _data.AddLast(paper);
			bool success = _dict.TryAdd(paper.Handle.ToLower(), node);
			if (success)
				addLegacyHandles(node);
			else
				_data.RemoveLast();
		}
	}

	public int GetPaperCount() => _data.Count;

	public string? GetPaperUrl(string paperHandle)
	{
		if (!_dict.ContainsKey(paperHandle.ToLower()))
			return null;

		return _urlPrefix + paperHandle;
	}
	public string? GetPaperData(string paperHandle)
	{
		if (!_dict.ContainsKey(paperHandle))
			return null;

		Assembly assembly = this.GetType().Assembly;

		using Stream articleStream = assembly.GetManifestResourceStream($"{_papersNamespace}.{paperHandle}.md")!;
		using StreamReader articleReader = new(articleStream);
		string markdown = articleReader.ReadToEnd();
		return markdown;
	}

	public IEnumerable<PaperMetadata> GetAll() => _data.Reverse();

	public PaperMetadata? Get(string handle)
	{
		handle = handle.ToLower();
		_dict.TryGetValue(handle, out LinkedListNode<PaperMetadata>? result);

		return result?.Value;
	}

	public PaperMetadata? GetNext(string handle)
	{
		handle = handle.ToLower();
		_dict.TryGetValue(handle, out LinkedListNode<PaperMetadata>? node);
		return node?.Next?.Value;
	}

	public PaperMetadata? GetPrevious(string handle)
	{
		handle = handle.ToLower();
		_dict.TryGetValue(handle, out LinkedListNode<PaperMetadata>? node);
		return node?.Previous?.Value;
	}

	private void addLegacyHandles(LinkedListNode<PaperMetadata> node)
	{
		bool success = _legacyHandles.TryGetValue(node.Value.Handle.ToLower(), out List<string>? legacyHandles);
		if (success)
			foreach (string legacyHandle in legacyHandles!)
			{
				if (_dict.TryGetValue(legacyHandle, out LinkedListNode<PaperMetadata>? nodeToRemove))
				{
					_data.Remove(nodeToRemove);
					_dict.Remove(legacyHandle);
				}
				_dict.Add(legacyHandle, node);
			}
	}
}