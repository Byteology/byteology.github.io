namespace Byteology.Website.Thoughts;

public partial class ArticleLayout : LayoutComponentBase
{
	private ArticleMetadata? _prevArticle, _nextArticle;

	[Inject]
	private ArticlesRepository _articlesRepository { get; set; } = default!;

	internal void SetArticleMetadata(string metadataHandle)
	{
		_prevArticle = _articlesRepository.GetPrevious(metadataHandle);
		_nextArticle = _articlesRepository.GetNext(metadataHandle);

		StateHasChanged();
	}
}
