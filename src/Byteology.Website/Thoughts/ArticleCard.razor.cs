namespace Byteology.Website.Thoughts;

public partial class ArticleCard : ComponentBase
{
	[Parameter, EditorRequired]
	public ArticleInfo Article { get; set; } = default!;
}