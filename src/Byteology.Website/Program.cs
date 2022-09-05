using Byteology.Website;
using Byteology.Website.Inquiring;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

ConfigureServices(builder.Services);

await builder.Build().RunAsync();

// This method is required by the prerenderer
static void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<IInquiryService, GoogleDriveInquiryService>();
    services.AddHttpClient<IInquiryService, GoogleDriveInquiryService>();
    services.AddSingleton((services) => new ModelReader(typeof(Program).Assembly, new(JsonSerializerDefaults.Web)
    {
        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
    }));

}