namespace Byteology.Website.Inquiry;

using Byteology.Website.Inquiry.Service;

public partial class InquiryForm : ComponentBase
{
	private readonly InquiryData _inquiryData = new();

	[Inject]
	private IInquiryService _inquiryService { get; set; } = default!;

	[Parameter]
	public EventCallback<SubmissionEventArgs> OnSubmit { get; set; }

	private async Task onSubmit()
	{
		if (!string.IsNullOrEmpty(_inquiryData.Honeycomb))
			return;

		bool result = false;
		try
		{
			result = await _inquiryService.SendInquiryAsync(_inquiryData);
		}
		catch { /* We don't want to expose details about the error. */ }

		await OnSubmit.InvokeAsync(new SubmissionEventArgs(result));
	}

	public class SubmissionEventArgs : EventArgs
	{
		public bool Success { get; private set; }

		public SubmissionEventArgs(bool success)
		{
			Success = success;
		}
	}
}
