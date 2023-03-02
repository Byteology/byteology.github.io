namespace Byteology.Website.Inquiry;

using Byteology.Website.Inquiry.Contacts;

public partial class InquiryComponent : ComponentBase
{
	[Parameter]
	public RenderFragment? Sidebar { get; set; }

	private string _state = "initial";

	private void onSubmit(InquiryForm.SubmissionEventArgs args)
	{
		_state = args.Success ? "success" : "error";
	}

	private void onRetry()
	{
		_state = "not-submitted";
	}
}
