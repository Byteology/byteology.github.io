﻿namespace Byteology.Website.Components;

using Microsoft.JSInterop;

public partial class Page : ComponentBase, IDisposable
{
    private bool _comesFromFullPageScrolling;
    private bool _fadeIn;
    
    [Inject]
    private StateContainer _state { get; set; } = default!; 

    [Inject]
    private IJSRuntime _jsRuntimeAsync { get; set; } = default!;
    private IJSInProcessRuntime _jsRuntime => (IJSInProcessRuntime)_jsRuntimeAsync;

    [Parameter]
    public bool FullPageScrolling { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        _comesFromFullPageScrolling = _state.FullPageScrolling;
        _state.FullPageScrolling = FullPageScrolling;

        _state.InitialLoad = _state.InitialLoad == null;
        _fadeIn = !_state.InitialLoad.Value;
    }

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);

        if (firstRender)
        {
            if (FullPageScrolling)
                _jsRuntime.InvokeVoid("fps.start");
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing && FullPageScrolling)
            _jsRuntime.InvokeVoid("fps.stop");
    }
}