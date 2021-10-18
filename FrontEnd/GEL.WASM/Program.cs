using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using GEL.WASM;
using GEL.WASM.Services;
using GEL.WASM.Services.IServices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
var config = builder.Configuration.Build();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient<IPostService, PostService>();
StaticDetails.ProductApiBase = config["ServiceUrls:PostApi"];
builder.Services.AddScoped<IPostService, PostService>();

await builder.Build().RunAsync();
