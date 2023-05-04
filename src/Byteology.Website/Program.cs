using Byteology.Website;
using Byteology.Website.Inquiry;
using Byteology.Website.Inquiry.Service;
using Byteology.Website.Thoughts;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Ljbc1994.Blazor.IntersectionObserver;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

ConfigureServices(builder.Services);

await builder.Build().RunAsync();

// This method is required by the pre-renderer
static void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<LayoutStateContainer>();
    services.AddSingleton<ArticlesRepository>();
    services.AddSingleton<IInquiryService, GoogleDriveInquiryService>();
    services.AddHttpClient<IInquiryService, GoogleDriveInquiryService>();
    services.AddIntersectionObserver();
}
