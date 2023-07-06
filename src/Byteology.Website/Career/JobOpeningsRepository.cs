namespace Byteology.Website.Career;

using Byteology.Website.Shared.MarkdownRendering;

public class JobOpeningsRepository : PapersRepository
{
	public JobOpeningsRepository() : base(getPapersMetadata(), "career", getJobOpeningsNamespace()) { }

	private static PaperMetadata[] getPapersMetadata()
	{
		PaperMetadata[] result =
			GetPaperMetadataFromEmbeddedJson(typeof(JobOpeningsRepository).Assembly, "Career.Data.openings-list.json");

		return result;
	}

	private static string getJobOpeningsNamespace()
	{
		return $"{typeof(JobOpeningsRepository).Namespace}.Data";
	}
}