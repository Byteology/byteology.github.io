namespace Byteology.Website.Shared.MarkdownRendering;

public partial class PaperList : ComponentBase
{
	[Parameter, EditorRequired]
	public PapersRepository PapersRepository { get; set; } = default!;
}