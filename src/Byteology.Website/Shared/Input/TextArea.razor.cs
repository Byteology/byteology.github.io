namespace Byteology.Website.Shared.Input;

using Microsoft.AspNetCore.Components.Forms;

public partial class TextArea : InputTextArea
{
	private readonly Guid _id = Guid.NewGuid();
	private string? _value;

	[Parameter]
	public string? Placeholder { get; set; }

	[Parameter]
	public string? Label { get; set; }

	private void onValueChanged(ChangeEventArgs e)
	{
		_value = (string?)e.Value;
	}
}
