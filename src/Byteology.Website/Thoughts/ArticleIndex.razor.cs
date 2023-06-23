namespace Byteology.Website.Thoughts;

using System.Text;
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
				markdown.AppendLine($"{indent}1. <button b-target=\"{block.Id}\">{block.Title}</button>");
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

}