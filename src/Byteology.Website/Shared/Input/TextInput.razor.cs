namespace Byteology.Website.Shared.Input;

using Microsoft.AspNetCore.Components.Forms;

public partial class TextInput : InputText
{
	private readonly Guid _id = Guid.NewGuid();

	[Parameter]
	public string? Placeholder { get; set; }

	[Parameter]
	public string? Label { get; set; }
}
