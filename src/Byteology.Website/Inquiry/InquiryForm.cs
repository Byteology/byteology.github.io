namespace Byteology.Website.Inquiry;

using Byteology.Website.Inquiry.Service;
using Microsoft.AspNetCore.Components.Forms;

public partial class InquiryForm<TData> : ComponentBase
	where TData : InquiryDataBase, new()
{
	[Inject]
	private IInquiryService _inquiryService { get; set; } = default!;

	protected readonly TData InquiryData = new();

	[Parameter]
	public EventCallback<SubmissionEventArgs> OnSubmit { get; set; }

	protected async Task Submit()
	{
		if (!string.IsNullOrEmpty(InquiryData.Honeycomb))
			return;

		bool result = false;
		try
		{
			result = await _inquiryService.SendInquiryAsync(InquiryData);
		}
		catch { /* We don't want to expose details about the error. */ }

		await OnSubmit.InvokeAsync(new SubmissionEventArgs(result));
	}


}
