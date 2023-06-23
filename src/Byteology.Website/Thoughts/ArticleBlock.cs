namespace Byteology.Website.Thoughts;

public class ArticleBlock
{
	public string Id { get; init; }

	public int HeaderNumber { get; init; }
	public string Title { get; init; }

	public string Text { get; init; }

	public ArticleBlock(string id, int headerNumber, string title, string text)
	{
		Id = id;
		HeaderNumber = headerNumber;
		Title = title;
		Text = text;
	}
}