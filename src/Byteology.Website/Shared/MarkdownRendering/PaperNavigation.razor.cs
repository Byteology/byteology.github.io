namespace Byteology.Website.Shared.MarkdownRendering;

public partial class PaperNavigation : ComponentBase
{
	[Parameter, EditorRequired]
	public PapersRepository PapersRepository { get; set; } = default!;

	[Parameter, EditorRequired]
	public string CurrentPaperHandle { get; set; } = default!;

	private PaperMetadata? _prevPaper, _nextPaper;

	protected override void OnParametersSet()
	{
		base.OnParametersSet();

		_prevPaper = PapersRepository.GetPrevious(CurrentPaperHandle);
		_nextPaper = PapersRepository.GetNext(CurrentPaperHandle);
	}
}