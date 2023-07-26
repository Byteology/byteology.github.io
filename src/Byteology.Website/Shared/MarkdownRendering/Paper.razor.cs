namespace Byteology.Website.Shared.MarkdownRendering;

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

	private MarkupString? _intro;
	private MarkupString? _content;
	private IEnumerable<PaperIndexData>? _indexData;

	private PaperMetadata? _metadata;

	protected override void OnParametersSet()
	{
		base.OnParametersSet();

		_metadata = getMetadata(Handle);
		string? markdown = _metadata != null ? PapersRepository.GetPaperData(_metadata.Handle) : null;

		if (markdown != null)
		{
			MarkdownParser parser = new(markdown, _markdownPipeline);
			_intro = new MarkupString(parser.GetIntro());
			_content = new MarkupString(parser.GetContent());
			_indexData = parser.GetIndexData();

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
}