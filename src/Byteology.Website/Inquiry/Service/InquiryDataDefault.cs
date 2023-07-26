namespace Byteology.Website.Inquiry.Service;

public class InquiryDataDefault : InquiryDataBase
{
	[Required]
	public string? Message { get; set; }

	public override List<KeyValuePair<string, string>> ToPayload()
	{
		List<KeyValuePair<string, string>> payload = base.ToPayload();
		payload.Add(new KeyValuePair<string, string>(nameof(Message), Message ?? ""));
		return payload;
	}
}
