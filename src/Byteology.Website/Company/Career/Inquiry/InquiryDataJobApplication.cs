namespace Byteology.Website.Company.Career.Inquiry;

using Byteology.Website.Inquiry.Service;

public class InquiryDataJobApplication : InquiryDataBase
{
	[Required]
	public string? File { get; set; }

	public override List<KeyValuePair<string, string>> ToPayload()
	{
		List<KeyValuePair<string, string>> payload = base.ToPayload();
		payload.Add(new KeyValuePair<string, string>(nameof(File), File ?? ""));
		return payload;
	}
}
