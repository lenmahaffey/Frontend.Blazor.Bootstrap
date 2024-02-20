using MeetingManager.Frontend.Blazor;
using MeetingManager.Frontend.Blazor.Areas.Contacts;
using MeetingManager.Frontend.Blazor.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<AlertService>();
builder.Services.AddScoped<AppStateService>();
builder.Services.AddScoped<ContactService>();
builder.Services.AddScoped(x => new HttpClient { BaseAddress = new Uri("http://localhost:5001/") });

await builder.Build().RunAsync();
