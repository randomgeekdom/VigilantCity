using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VigilantCity.Blazor;
using VigilantCity.Blazor.Services;
using VigilantCity.Core.Services;
using VigilantCity.Core.Services.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) }); 
builder.Services.AddBlazoredLocalStorageAsSingleton();

builder.Services.AddScoped<ICityLoader, CityLoader>();
builder.Services.AddScoped<ICityStarter, CityStarter>();
builder.Services.AddScoped<IIncidentFactory, IncidentFactory>();

await builder.Build().RunAsync();
