namespace Byteology.Website.Thoughts;

using System.Text;
using System.Text.RegularExpressions;
using Markdig;
using Microsoft.JSInterop;

public partial class ArticleIndex : ComponentBase
{
	[Inject]
	private IJSRuntime _jsRuntimeAsync { get; set; } = default!;
	private IJSInProcessRuntime _jsRuntime => (IJSInProcessRuntime)_jsRuntimeAsync;

	[Parameter, EditorRequired]
	public IEnumerable<ArticleBlock> Blocks { get; set; } = default!;

	private MarkupString _content = default!;

	protected override void OnParametersSet()
	{
		base.OnParametersSet();

		StringBuilder markdown = new();
		foreach (ArticleBlock block in Blocks)
		{
			if (block.HeaderNumber > 1)
			{
				string indent = new(' ', (block.HeaderNumber - 2) * 3);
				markdown.AppendLine($"{indent}1. <button b-target=\"{block.Id}\">{sanitizeTitle(block.Title)}</button>");
			}
		}
		_content = new MarkupString(Markdown.ToHtml(markdown.ToString()));
	}

	protected override void OnAfterRender(bool firstRender)
	{
		base.OnAfterRender(firstRender);

		string[] navIds = Blocks.Where(x => x.HeaderNumber > 1).Select(x => x.Id).ToArray();
		_jsRuntime.InvokeVoid("initIndex", (object)navIds);
	}

	[GeneratedRegex(@"<[^<]*/>", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)]
	private static partial Regex getSelfClosingTagRegex();
	[GeneratedRegex(@"<[^</]*>", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)]
	private static partial Regex getOpeningTagRegex();
	[GeneratedRegex(@"\s+.*", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)]
	private static partial Regex getTagAttributesRegex();

	private static string sanitizeTitle(string title)
	{
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