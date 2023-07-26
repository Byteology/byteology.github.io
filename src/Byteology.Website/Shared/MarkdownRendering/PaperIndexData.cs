namespace Byteology.Website.Shared.MarkdownRendering;

using System.Text.RegularExpressions;

public partial class PaperIndexData
{
	public string Id { get; init; }
	public string Title { get; init; }
	public int Level { get; }

	public PaperIndexData(string id, string headingHtml)
	{
		Id = id;
		Title = sanitizeTitle(headingHtml);
		Level = id.Split('-', StringSplitOptions.RemoveEmptyEntries).Length - 1;
	}

	[GeneratedRegex(@"<[^<]*/\s*>", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)]
	private static partial Regex getSelfClosingTagRegex();
	[GeneratedRegex(@"<[^</]*>", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)]
	private static partial Regex getOpeningTagRegex();
	[GeneratedRegex(@"\s+.*", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)]
	private static partial Regex getTagAttributesRegex();

	private static string sanitizeTitle(string title)
	{
		int endOfOpeningTagIndex = title.IndexOf('>') + 1;
		int startOfOpeningTagIndex = title.LastIndexOf('<');
		title = title[endOfOpeningTagIndex..startOfOpeningTagIndex].Trim();

		title = getSelfClosingTagRegex().Replace(title, string.Empty);

		while (true)
		{
			MatchCollection matches = getOpeningTagRegex().Matches(title);
			if (matches.Count == 0)
				break;

			Match match = matches[^1];
			string tag = match.Value[1..^1].Trim();
			tag = getTagAttributesRegex().Replace(tag, string.Empty);

			MatchCollection closeMatches = Regex.Matches(title, @"<\s*/\s*" + tag + @"\s*>");
			if (closeMatches.Count != 0)
			{
				Match closeMatch = closeMatches.First(x => x.Index > match.Index);
				title = title.Remove(match.Index, closeMatch.Index + closeMatch.Length - match.Index);
			}
			else
				title = title.Remove(match.Index, match.Length);
		}

		return title;
	}
}