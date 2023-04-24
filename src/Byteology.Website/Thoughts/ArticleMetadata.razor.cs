namespace Byteology.Website.Thoughts;

public partial class ArticleMetadata : ComponentBase
{
	[Parameter, EditorRequired]
	public ArticleInfo Info { get; set; } = default!;
}