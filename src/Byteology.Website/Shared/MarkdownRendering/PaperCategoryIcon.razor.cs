namespace Byteology.Website.Shared.MarkdownRendering;

public partial class PaperCategoryIcon : ComponentBase
{
	[Parameter]
	public PaperCategory Category { get; set; }

	private Type getIconType()
	{
		return Category switch
		{
			PaperCategory.SoftwareDevelopment => typeof(Icons.CogwheelIcon),
			PaperCategory.Recruitment => typeof(Icons.CvIcon),
			PaperCategory.Trainings => typeof(Icons.WhiteboardIcon),
			PaperCategory.Business => typeof(Icons.HandMoneyIcon),
			_ => typeof(Icons.CoreIcon)
		};
	}
}