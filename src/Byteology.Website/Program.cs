using Byteology.Website;
using Byteology.Website.Inquiring;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Ljbc1994.Blazor.IntersectionObserver;
using Microsoft.Extensions.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

ConfigureServices(builder.Services);

await builder.Build().RunAsync();

// This method is required by the prerenderer
static void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<StateContainer>();
    services.AddSingleton<IInquiryService, GoogleDriveInquiryService>();
    services.AddHttpClient<IInquiryService, GoogleDriveInquiryService>();
    services.AddIntersectionObserver();
}