namespace Byteology.Website.Pages;

using System.Net.Http.Json;

public partial class FetchData : ComponentBase
{
    [Inject] 
    private HttpClient _http { get; set; } = default!;

    private WeatherForecast[]? _forecasts;

    protected override async Task OnInitializedAsync()
    {
        _forecasts = await _http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
    }

    private sealed record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
