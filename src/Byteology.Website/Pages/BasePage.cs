namespace Byteology.Website.Pages;

using Microsoft.JSInterop;

public abstract class BasePage : ComponentBase
{
    [Inject]
    protected IJSRuntime JsInterop { get; set; } = default!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
            await JsInterop.InvokeVoidAsync("observeIntersections");
    }
}
