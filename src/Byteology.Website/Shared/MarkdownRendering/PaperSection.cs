namespace Byteology.Website.Shared.MarkdownRendering;

public class PaperSection
{
	public string Id { get; init; }

	public int HeaderNumber { get; init; }
	public string Title { get; init; }

	public string Text { get; init; }

	public PaperSection(string id, int headerNumber, string title, string text)
	{
		Id = id;
		HeaderNumber = headerNumber;
		Title = title;
		Text = text;
	}
}