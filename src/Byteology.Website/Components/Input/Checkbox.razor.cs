namespace Byteology.Website.Components.Input;

using Microsoft.AspNetCore.Components.Forms;

public partial class Checkbox : InputCheckbox
{
    private readonly Guid _id = Guid.NewGuid();

    [Parameter]
    public string? Label { get; set; }

    [Parameter]
    public string? Class { get; set; }
}
