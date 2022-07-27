namespace Byteology.Website.Pages;

using Microsoft.JSInterop;
using System.Threading.Tasks;

public partial class Home : ComponentBase, IAsyncDisposable
{
    [Inject]
    private IJSRuntime _jsInterop { get; set; } = default!;
    private IJSObjectReference? _module;
    private DotNetObjectReference<Home>? _dotNetReference;

    private int _currentSlide = 0;
    private int _slidesCount = 3;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        _dotNetReference = DotNetObjectReference.Create(this);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _module = await _jsInterop.InvokeAsync<IJSObjectReference>("import", "./js/home-page.js");
            await _module.InvokeVoidAsync("init", _currentSlide, _slidesCount, _dotNetReference);
        }
    }

    [JSInvokable]
    public void OnSlideChanged(int slideIndex)
    {
        _currentSlide = slideIndex;
        StateHasChanged();
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore();
        GC.SuppressFinalize(this);
    }

    public virtual async ValueTask DisposeAsyncCore()
    {
        if (_module != null)
            await _module.InvokeVoidAsync("dispose");

        _module = null;
    }
}
