namespace Byteology.Website.Thoughts;

public abstract class Article : ComponentBase
{
	private bool _metadataSentToLayout;

	[CascadingParameter(Name = "Layout")]
	public ArticleLayout? Layout { get; set; }

	protected abstract string GetMetadataHandle();

	protected override void OnParametersSet()
	{
		base.OnParametersSet();

		if (!_metadataSentToLayout && Layout != null)
		{
			_metadataSentToLayout = true;
			Layout.SetArticleMetadata(GetMetadataHandle());
		}
	}
}
