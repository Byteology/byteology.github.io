namespace Byteology.Website.Thoughts;

public partial class NextPrevArticle : ComponentBase
{
	[Inject]
	private ArticlesRepository _articlesRepository { get; set; } = default!;

	[Parameter, EditorRequired]
	public string CurrentArticleHandle { get; set; } = default!;

	private ArticleMetadata? _prevArticle, _nextArticle;

	protected override void OnParametersSet()
	{
		base.OnParametersSet();

		_prevArticle = _articlesRepository.GetPrevious(CurrentArticleHandle);
		_nextArticle = _articlesRepository.GetNext(CurrentArticleHandle);
	}
}