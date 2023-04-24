namespace Byteology.Website.Thoughts;

public partial class ArticleCategoryIcon : ComponentBase
{
	[Parameter, EditorRequired]
	public ArticleCategory Category { get; set; }

	private Type getIconType()
	{
		return Category switch
		{
			ArticleCategory.SoftwareDevelopment => typeof(Icons.CogwheelIcon),
			ArticleCategory.Recruitment => typeof(Icons.CvIcon),
			ArticleCategory.Trainings => typeof(Icons.WhiteboardIcon),
			ArticleCategory.Business => typeof(Icons.HandMoneyIcon),
			_ => typeof(Icons.CoreIcon)
		};
	}

}