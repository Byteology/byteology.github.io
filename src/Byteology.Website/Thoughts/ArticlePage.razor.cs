namespace Byteology.Website.Thoughts;

public partial class ArticlePage : ComponentBase
{
	[Parameter]
	public string Handle { get; set; } = default!;

	[Inject]
	private ArticlesRepository _articlesRepository { get; set; } = default!;
}
