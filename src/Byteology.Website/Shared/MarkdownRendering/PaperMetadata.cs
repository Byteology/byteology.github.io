namespace Byteology.Website.Shared.MarkdownRendering;

public class PaperMetadata
{
	public string Handle { get; set; } = default!;
	public PaperCategory Category { get; set; }
	public string? Title { get; set; } = default!;
	public string? Subtitle { get; set; }
	public string? Description { get; set; } = default!;
	public string[]? Keywords { get; set; }
}
