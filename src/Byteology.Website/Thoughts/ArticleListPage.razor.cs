namespace Byteology.Website.Thoughts;

public partial class ArticleListPage : ComponentBase
{
	[Inject]
	private ArticlesRepository _articlesRepository { get; set; } = default!;
}
