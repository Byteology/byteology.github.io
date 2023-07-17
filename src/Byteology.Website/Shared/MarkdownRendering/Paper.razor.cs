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

	[GeneratedRegex(@"(?=<h\d\s*[^>]*>.*</h\d>)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)]
	private static partial Regex getHeadingRegex();

	[GeneratedRegex(@"^<h\d\s*[^>]*>", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)]
	private static partial Regex getHeadingStartRegex();

	[GeneratedRegex(@"class=""[^""]*""", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)]
	private static partial Regex getClassRegex();

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

	private static PaperSection getSection(string blockData, ref List<int> lastSectionId)
	{
		blockData = blockData.Trim();

		bool startsWithHeading = !string.IsNullOrWhiteSpace(blockData) && getHeadingStartRegex().IsMatch(blockData);

		if (!startsWithHeading)
			return new PaperSection(
				id: string.Empty,
				headerNumber: 1,
				title: string.Empty,
				text: blockData,
				classes: string.Empty
			);

		int headingNumber = int.Parse(blockData[2].ToString());
		int headingEnd = blockData.IndexOf($"</h{headingNumber}>");
		int indexOfContentStart = blockData.IndexOf('>') + 1;

		string classes = getClassRegex().Match(blockData.Substring(0, indexOfContentStart)).Value;
		if (!string.IsNullOrEmpty(classes))
			classes = classes[7..^1];

		string title = blockData[indexOfContentStart..headingEnd].Trim();
		string content = blockData[(headingEnd + 5)..].Trim();
		string id = string.Empty;

		if (headingNumber > 1)
		{
			StringBuilder idBuilder = new();
			idBuilder.Append("section");

			if (lastSectionId.Count > headingNumber - 1)
				lastSectionId.RemoveRange(headingNumber - 1, lastSectionId.Count - (headingNumber - 1));

			if (lastSectionId.Count == headingNumber - 1)
				lastSectionId[^1]++;
			else while (lastSectionId.Count != headingNumber - 1)
					lastSectionId.Add(1);

			for (int i = 0; i < lastSectionId.Count; i++)
				idBuilder.Append($"-{lastSectionId[i]}");

			id = idBuilder.ToString();
		}

		return new PaperSection(
			id: id,
			headerNumber: headingNumber,
			title: title,
			text: content,
			classes: classes
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

		bool subsectionOpened = false;
		bool cardOpened = false;

		foreach (PaperSection section in _sections.Skip(1))
		{
			if (subsectionOpened && section.HeaderNumber <= 3)
			{
				value.AppendLine("</b-subsection>");
				subsectionOpened = false;
			}

			if (cardOpened && section.HeaderNumber <= 4)
			{
				value.AppendLine("</b-card>");
				cardOpened = false;
			}

			if (section.HeaderNumber == 3)
			{
				value.AppendLine("<b-subsection>");
				subsectionOpened = true;
			}

			if (section.HeaderNumber == 4)
			{
				value.AppendLine("<b-card>");
				cardOpened = true;
			}

			string classesString = string.IsNullOrEmpty(section.Classes) ? string.Empty : $" class=\"{section.Classes}\"";

			value.AppendLine($"<h{section.HeaderNumber} name=\"{section.Id}\"{classesString}>{section.Title}</h{section.HeaderNumber}>");
			value.AppendLine(section.Text);
		}

		value = value.Replace("<hr />", "</section><section>");

		if (subsectionOpened)
			value.AppendLine("</b-subsection>");

		value.AppendLine("</section>");

		return new MarkupString(value.ToString());
	}
}