using Microsoft.FluentUI.AspNetCore.Components;
using SizingCalculator.BlazorApp.Components;
using SizingCalculator.Persistence;
using SizingCalculator.Application;

var builder = WebApplication.CreateBuilder(args);

var applicationSettingsConfiguration = builder.Configuration.GetSection(ApplicationSettings.Key);
builder.Services.Configure<ApplicationSettings>(applicationSettingsConfiguration);
var applicationSettings = applicationSettingsConfiguration.Get<ApplicationSettings>()!;

builder.Services.ConfigurePersistence(applicationSettings.ConnectionString);
builder.Services.ConfigureApplication();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddFluentUIComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
