namespace Byteology.Website.Thoughts;

using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Markdig;

public partial class ArticlePage : ComponentBase
{
	[Parameter]
	public string Handle { get; set; } = default!;

	ArticleBlock[] _blocks = default!;

	private MarkupString _intro, _content = default!;

	private ArticleMetadata? _metadata;

	[Inject]
	private ArticlesRepository _articlesRepository { get; set; } = default!;

	[GeneratedRegex(@"(?=<h\d>.*</h\d>)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)]
	private static partial Regex getHeadingRegex();

	[GeneratedRegex(@"^<h\d>", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)]
	private static partial Regex getHeadingCloseRegex();

	protected override void OnParametersSet()
	{
		base.OnParametersSet();

		_metadata = getMetadata(Handle);

		if (_metadata != null)
		{
			string markdown = getData(_metadata);
			_blocks = parseMarkdown(markdown);

			_intro = getIntroContent();
			_content = fillContent();
		}
	}

	private ArticleMetadata? getMetadata(string handle)
	{
		ArticleMetadata? result = null;
		if (!string.IsNullOrEmpty(handle))
			result = _articlesRepository.Get(handle);

		return result;
	}

	private static string getData(ArticleMetadata metadata)
	{
		Assembly assembly = typeof(ArticlePage).Assembly;
		string path = $"{assembly.GetName().Name}.Thoughts.Articles";

		using Stream articleStream = assembly.GetManifestResourceStream($"{path}.{metadata.Handle}.md")!;
		using StreamReader articleReader = new(articleStream);
		string markdown = articleReader.ReadToEnd();
		return markdown;
	}

	private static ArticleBlock[] parseMarkdown(string markdown)
	{
		string htmlString = Markdown.ToHtml(markdown);
		string[] blockSplit = getHeadingRegex().Split(htmlString);

		List<int> lastBlockId = new();
		ArticleBlock[] blocks = blockSplit
			.Where(x => !string.IsNullOrWhiteSpace(x))
			.Select(x => getBlock(x, ref lastBlockId))
			.ToArray();

		return blocks;
	}

	private static ArticleBlock getBlock(string blockData, ref List<int> lastBlockId)
	{
		blockData = blockData.Trim();

		bool startsWithHeading = !string.IsNullOrWhiteSpace(blockData) && getHeadingCloseRegex().IsMatch(blockData);

		if (!startsWithHeading)
			return new ArticleBlock(
				id: string.Empty,
				headerNumber: 1,
				title: string.Empty,
				text: blockData
			);

		int headingNumber = int.Parse(blockData[2].ToString());
		int headingEnd = blockData.IndexOf($"</h{headingNumber}>");
		string title = blockData[4..headingEnd];
		string content = blockData[(headingEnd + 5)..];
		string id = string.Empty;

		if (headingNumber > 1)
		{
			StringBuilder idBuilder = new();
			idBuilder.Append("section");

			if (lastBlockId.Count > headingNumber - 1)
				lastBlockId.RemoveRange(headingNumber - 1, lastBlockId.Count - (headingNumber - 1));

			if (lastBlockId.Count == headingNumber - 1)
				lastBlockId[^1]++;
			else
				lastBlockId.Add(1);

			for (int i = 0; i < lastBlockId.Count; i++)
				idBuilder.Append($"-{lastBlockId[i]}");

			id = idBuilder.ToString();
		}

		return new ArticleBlock(
			id: id,
			headerNumber: headingNumber,
			title: title,
			text: content
		);
	}

	private MarkupString getIntroContent()
	{
		return new MarkupString(_blocks[0].Text);
	}

	private MarkupString fillContent()
	{
		bool blockOpened = false;
		StringBuilder value = new();

		foreach (ArticleBlock block in _blocks.Skip(1))
		{
			if (block.HeaderNumber == 2)
			{
				if (blockOpened)
					value.AppendLine("</section>");
				value.AppendLine("<section>");
				blockOpened = true;
			}
			value.AppendLine($"<h{block.HeaderNumber} name=\"{block.Id}\">{block.Title}</h{block.HeaderNumber}>");
			value.AppendLine(block.Text);
		}

		if (blockOpened)
			value.AppendLine("</section>");

		return new MarkupString(value.ToString());
	}
}
