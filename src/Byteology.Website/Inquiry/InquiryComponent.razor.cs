namespace Byteology.Website.Inquiry;

using Byteology.Website.Inquiry.Contacts;

public partial class InquiryComponent : ComponentBase
{
	[Parameter]
	public RenderFragment? Sidebar { get; set; }

	[Parameter, EditorRequired]
	public Type InquiryFormType { get; set; } = default!;

	private string _state = "initial";

	private void onSubmit(SubmissionEventArgs args)
	{
		_state = args.Success ? "success" : "error";
	}

	private void onRetry()
	{
		_state = "not-submitted";
	}

	private Dictionary<string, object> getDynamicComponentParameters()
	{
		Dictionary<string, object> result = new();
		result.Add("OnSubmit", EventCallback.Factory.Create<SubmissionEventArgs>(this, onSubmit));
		return result;
	}
}
