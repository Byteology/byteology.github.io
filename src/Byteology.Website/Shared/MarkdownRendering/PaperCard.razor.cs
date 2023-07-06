namespace Byteology.Website.Shared.MarkdownRendering;

public partial class PaperCard : ComponentBase
{
	[Parameter, EditorRequired]
	public PaperMetadata Metadata { get; set; } = default!;

	[Parameter, EditorRequired]
	public PapersRepository PapersRepository { get; set; } = default!;
}