namespace Byteology.Website.FullPageScrolling;

using Microsoft.JSInterop;

public partial class FullPageScrollingLayout : LayoutComponentBase, IAsyncDisposable
{
    [Inject]
    private IJSRuntime _jsRuntime { get; set; } = default!;
    private IJSObjectReference? _module { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        await _jsRuntime.InvokeVoidAsync("preventPitbarHiding");
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _module = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "./js/full-page-scrolling-layout.js");
            await _module.InvokeVoidAsync("init");
        }
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore();
        GC.SuppressFinalize(this);
    }

    protected virtual async ValueTask DisposeAsyncCore()
    {
        await _jsRuntime.InvokeVoidAsync("resetPitbarHiding");
    }
}
