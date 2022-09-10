namespace Byteology.Website.Routing;

using Microsoft.AspNetCore.Components.Routing;
using System.Web;

public sealed class HashConventionRouter : IComponent, IHandleAfterRender, IDisposable
{
    private RenderHandle _renderHandle;
    private bool _navigationInterceptionEnabled;
    private string _location = default!;

    [Inject] private NavigationManager _navigationManager { get; set; } = default!;
    [Inject] private INavigationInterception _navigationInterception { get; set; } = default!;
    [Inject] private RouteManager _routeManager { get; set; } = default!;

    [Parameter] public RenderFragment NotFound { get; set; } = default!;
    [Parameter] public RenderFragment<RouteData> Found { get; set; } = default!;

    public void Attach(RenderHandle renderHandle)
    {
        _renderHandle = renderHandle;
        _location = _navigationManager.Uri;
        _navigationManager.LocationChanged += handleLocationChanged;
    }

    public Task SetParametersAsync(ParameterView parameters)
    {
        parameters.SetParameterProperties(this);

        if (Found == null)
        {
            throw new InvalidOperationException($"The {nameof(HashConventionRouter)} component requires a value for the parameter {nameof(Found)}.");
        }

        if (NotFound == null)
        {
            throw new InvalidOperationException($"The {nameof(HashConventionRouter)} component requires a value for the parameter {nameof(NotFound)}.");
        }

        refresh();

        return Task.CompletedTask;
    }

    public Task OnAfterRenderAsync()
    {
        if (!_navigationInterceptionEnabled)
        {
            _navigationInterceptionEnabled = true;
            return _navigationInterception.EnableNavigationInterceptionAsync();
        }

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _navigationManager.LocationChanged -= handleLocationChanged;
    }

    private void handleLocationChanged(object? sender, LocationChangedEventArgs args)
    {
        _location = args.Location;
        refresh();
    }

    private void refresh()
    {
        string relativeUri = _navigationManager.ToBaseRelativePath(_location);
        Dictionary<string, object> parameters = new();

        int questionMarkIndex = relativeUri.IndexOf('?');
        if (questionMarkIndex > -1)
        {
            string queryString = relativeUri.Substring(questionMarkIndex);
            relativeUri = relativeUri.Substring(0, questionMarkIndex);
            parameters = parseQueryString(queryString);
        }

        string[] segments = relativeUri.Trim().Split('/', StringSplitOptions.RemoveEmptyEntries);
        Route? route = _routeManager.Match(segments);

        if (route != null)
        {
            RouteData routeData = new(
                route.Handler,
                parameters);

            _renderHandle.Render(Found(routeData));
        }
        else
        {
            _renderHandle.Render(NotFound);
        }
    }

    private static Dictionary<string, object> parseQueryString(string queryString)
    {
        Dictionary<string, object> result = new();

        var collection = HttpUtility.ParseQueryString(queryString);
        if (collection.HasKeys())
        {
            foreach (var key in collection.AllKeys)
            {
                object? obj = collection[key];
                if (key != null && obj != null)
                    result.Add(key, obj);
            }
        }

        return result;
    }
}