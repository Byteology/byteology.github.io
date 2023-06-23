namespace Byteology.Website.Thoughts;

public partial class ArticleList : ComponentBase
{
	[Inject]
	private ArticlesRepository _articlesRepository { get; set; } = default!;
}