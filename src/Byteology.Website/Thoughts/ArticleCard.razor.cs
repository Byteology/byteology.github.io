namespace Byteology.Website.Thoughts;

public partial class ArticleCard : ComponentBase
{
	[Parameter, EditorRequired]
	public ArticleMetadata Article { get; set; } = default!;
}