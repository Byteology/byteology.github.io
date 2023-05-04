namespace Byteology.Website.Thoughts;

public partial class ArticleIntro : ComponentBase
{
	[Parameter, EditorRequired]
	public ArticleMetadata Metadata { get; set; } = default!;

	[Parameter, EditorRequired]
	public RenderFragment ChildContent { get; set; } = default!;
}
