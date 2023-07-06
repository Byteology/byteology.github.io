namespace Byteology.Website.Shared.MarkdownRendering;

using System.Text;
using System.Text.RegularExpressions;
using Markdig;

public partial class Paper : ComponentBase
{

	[Parameter]
	public string Handle { get; set; } = default!;

	[Parameter, EditorRequired]
	public bool NavigationEnabled { get; set; }

	[Parameter, EditorRequired]
	public bool IndexEnabled { get; set; }

	[Parameter, EditorRequired]
	public string NotFoundUrl { get; set; } = default!;

	[Parameter, EditorRequired]
	public PapersRepository PapersRepository { get; set; } = default!;

	[Inject]
	private MarkdownPipeline _markdownPipeline { get; set; } = default!;

	[Inject]
	private NavigationManager _navigationManager { get; set; } = default!;

	PaperSection[] _sections = default!;

	private MarkupString _intro, _content = default!;

	private PaperMetadata? _metadata;

	[GeneratedRegex(@"(?=<h\d>.*</h\d>)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)]
	private static partial Regex getHeadingRegex();

	[GeneratedRegex(@"^<h\d>", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)]
	private static partial Regex getHeadingCloseRegex();

	protected override void OnParametersSet()
	{
		base.OnParametersSet();

		_metadata = getMetadata(Handle);
		string? markdown = _metadata != null ? PapersRepository.GetPaperData(_metadata.Handle) : null;

		if (markdown != null)
		{
			_sections = parseMarkdown(markdown);

			_intro = getIntroContent();
			_content = fillContent();
		}
		else
			_navigationManager.NavigateTo(NotFoundUrl);
	}

	private PaperMetadata? getMetadata(string handle)
	{
		PaperMetadata? result = null;
		if (!string.IsNullOrEmpty(handle))
			result = PapersRepository.Get(handle);

		return result;
	}

	private PaperSection[] parseMarkdown(string markdown)
	{
		string htmlString = Markdown.ToHtml(markdown, _markdownPipeline);
		string[] sectionSplit = getHeadingRegex().Split(htmlString);

		List<int> lastSectionId = new();
		PaperSection[] sections = sectionSplit
			.Where(x => !string.IsNullOrWhiteSpace(x))
			.Select(x => getSection(x, ref lastSectionId))
			.ToArray();

		return sections;
	}

	private static PaperSection getSection(string blockData, ref List<int> lastBlockId)
	{
		blockData = blockData.Trim();

		bool startsWithHeading = !string.IsNullOrWhiteSpace(blockData) && getHeadingCloseRegex().IsMatch(blockData);

		if (!startsWithHeading)
			return new PaperSection(
				id: string.Empty,
				headerNumber: 1,
				title: string.Empty,
				text: blockData
			);

		int headingNumber = int.Parse(blockData[2].ToString());
		int headingEnd = blockData.IndexOf($"</h{headingNumber}>");
		string title = blockData[4..headingEnd].Trim();
		string content = blockData[(headingEnd + 5)..].Trim();
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

		return new PaperSection(
			id: id,
			headerNumber: headingNumber,
			title: title,
			text: content
		);
	}

	private MarkupString getIntroContent()
	{
		string text = _sections[0].Text.EndsWith("<hr />") ? _sections[0].Text[..^6] : _sections[0].Text;
		return new MarkupString(text);
	}

	private MarkupString fillContent()
	{
		StringBuilder value = new("<section>");

		foreach (PaperSection section in _sections.Skip(1))
		{
			value.AppendLine($"<h{section.HeaderNumber} name=\"{section.Id}\">{section.Title}</h{section.HeaderNumber}>");
			value.AppendLine(section.Text);
		}

		value = value.Replace("<hr />", "</section><section>");
		value.AppendLine("</section>");

		return new MarkupString(value.ToString());
	}
}