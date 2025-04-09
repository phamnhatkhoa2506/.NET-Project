using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Admin;
using Admin.Services;
using Admin.Helpers;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<LanguageService>(); // Thêm service language 
builder.Services.AddSingleton<LanguageConstantsService>(); // Thêm service cho constants
builder.Services.AddScoped<PageStateManager>(); // Thêm manager quản lý gọi api cho các trangs

await builder.Build().RunAsync();
