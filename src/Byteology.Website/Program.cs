using Byteology.Website;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Ljbc1994.Blazor.IntersectionObserver;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

ConfigureServices(builder.Services, builder.HostEnvironment.BaseAddress);

await builder.Build().RunAsync();

// This method is required by the prerenderer
static void ConfigureServices(IServiceCollection services, string baseAddress)
{
    services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });
    services.AddIntersectionObserver();
}