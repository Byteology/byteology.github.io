namespace Byteology.Website.Components;

using Microsoft.JSInterop;

public partial class PageRoot : ByteologyComponent, IAsyncDisposable
{
    private bool _initialFullPageScrollingValue;

    [Inject]
    private IJSRuntime _jsRuntime { get; set; } = default!;
    private IJSObjectReference? _module { get; set; }

    [Parameter]
    public bool FullPageScrolling { get; set; }

    [Parameter]
    public bool DarkMode { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        if (FullPageScrolling != _initialFullPageScrollingValue)
            throw new InvalidOperationException($"The value of the parameter {nameof(FullPageScrolling)} can't be changed.");
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        _initialFullPageScrollingValue = FullPageScrolling;
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        if (FullPageScrolling)
            await _jsRuntime.InvokeVoidAsync("preventPitbarHiding");
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender && FullPageScrolling)
        {
            _module = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "./js/full-page-scrolling.js");
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
        if (FullPageScrolling)
            await _jsRuntime.InvokeVoidAsync("resetPitbarHiding");
    }
}
