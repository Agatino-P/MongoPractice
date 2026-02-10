using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MongoPractice.Wasm;
using MongoPractice.Wasm.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddApiServices();

string apiUrl = builder.Configuration["API_URL"] 
                ?? throw new InvalidOperationException("API_URL is not set.");

builder.Services.AddHttpClient<IApiService, ApiService>(client =>
{
    client.BaseAddress = new Uri(apiUrl);
});

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();