using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using GEL.WASM;
using GEL.WASM.Services;
using GEL.WASM.Services.IServices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
//var config = builder.Configuration.Build();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Auth0", options.ProviderOptions);
    options.ProviderOptions.ResponseType = "code";
});

builder.Services.AddHttpClient<IPostService, PostService>();
//StaticDetails.ProductApiBase = config["ServiceUrls:PostApi"];
StaticDetails.ProductApiBase = builder.Configuration["ServiceUrls:PostApi"];
builder.Services.AddScoped<IPostService, PostService>();

await builder.Build().RunAsync();
