namespace Byteology.Website.Services;

using Byteology.Website.Shared.MarkdownRendering;

public class ServicesInfoRepository : PapersRepository
{
	public ServicesInfoRepository() : base(
			paperList: getPapersMetadata(),
			urlPrefix: "services",
			papersNamespace: getArticlesNamespace(),
			defaultIcon: typeof(Icons.CogwheelIcon),
			legacyHandles: getLegacyHandles())
	{ }

	private static PaperMetadata[] getPapersMetadata()
	{
		PaperMetadata[] result =
			GetPaperMetadataFromEmbeddedJson(typeof(ServicesInfoRepository).Assembly, "Services.Data.services-list.json");

		return result;
	}


	private static string getArticlesNamespace()
	{
		return $"{typeof(ServicesInfoRepository).Namespace}.Data";
	}

	private static IEnumerable<(string legacyHandle, string newHandle)>? getLegacyHandles()
	{
		yield return new("software-development", "software-engineering");
	}
}