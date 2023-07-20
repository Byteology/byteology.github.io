namespace Byteology.Website.Shared.MarkdownRendering;

using System.Text;
using Markdig;
using Microsoft.JSInterop;

public partial class PaperIndex : ComponentBase
{
	[Inject]
	private IJSRuntime _jsRuntimeAsync { get; set; } = default!;
	private IJSInProcessRuntime _jsRuntime => (IJSInProcessRuntime)_jsRuntimeAsync;

	[Parameter, EditorRequired]
	public IEnumerable<PaperIndexData> Data { get; set; } = default!;

	private MarkupString _content = default!;

	protected override void OnParametersSet()
	{
		base.OnParametersSet();

		StringBuilder markdown = new();
		foreach (PaperIndexData point in Data)
		{
			string indent = new(' ', point.Level * 3);
			markdown.AppendLine($"{indent}1. <b-button b-target=\"{point.Id}\">{point.Title}</b-button>");
		}
		_content = new MarkupString(Markdown.ToHtml(markdown.ToString()));
	}

	protected override void OnAfterRender(bool firstRender)
	{
		base.OnAfterRender(firstRender);

		string[] navIds = Data.Select(x => x.Id).ToArray();
		_jsRuntime.InvokeVoid("initIndex", (object)navIds);
	}
}