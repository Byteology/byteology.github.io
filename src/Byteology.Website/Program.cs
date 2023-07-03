using Byteology.Website;
using Byteology.Website.Inquiry.Service;
using Byteology.Website.Thoughts;
using Ljbc1994.Blazor.IntersectionObserver;
using Markdig;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

ConfigureServices(builder.Services);
RegisterCustomElements(builder.RootComponents);

await builder.Build().RunAsync();

// This method is required by the pre-renderer
static void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<LayoutStateContainer>();
    services.AddSingleton<ArticlesRepository>();
    services.AddSingleton<IInquiryService, GoogleDriveInquiryService>();
    services.AddHttpClient<IInquiryService, GoogleDriveInquiryService>();
    services.AddIntersectionObserver();

	services.AddSingleton(new MarkdownPipelineBuilder()
		.UseCitations()
		.UseCustomContainers()
		.Build());
}

static void RegisterCustomElements(IJSComponentConfiguration configuration)
{
	configuration.RegisterCustomElement<Byteology.Website.Icons.DynamicIcon>("b-icon");
}
