namespace Byteology.Website.Shared.Input;

using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;

public partial class FileInput : InputText
{
	private readonly Guid _id = Guid.NewGuid();

	private string? _filename;

	[Parameter]
	public string? Label { get; set; }

	[Parameter]
	public string? ButtonText { get; set; }

	[Parameter]
	public string? Placeholder { get; set; }

	[Parameter]
	public string? AcceptedFiles { get; set; }

	[Parameter]
	public EventCallback<InputFileChangeEventArgs> OnChange { get; set; }

	private async Task onUpload(InputFileChangeEventArgs eventArgs)
	{
		string? base64 = null;

		if (eventArgs.File != null)
		{
			_filename = eventArgs.File.Name;

			using Stream stream = eventArgs.File.OpenReadStream();
			using MemoryStream memoryStream = new();
			await stream.CopyToAsync(memoryStream);
			byte[] bytes = memoryStream.ToArray();
			base64 = Convert.ToBase64String(bytes);
		}

		CurrentValue = base64;
	}
}
