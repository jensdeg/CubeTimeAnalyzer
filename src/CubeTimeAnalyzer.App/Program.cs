using CubeTimeAnalyzer.App.Client;
using CubeTimeAnalyzer.App.Components;

var builder = WebApplication.CreateBuilder(args);

if (args.Contains("--Aspire"))
{
    builder.AddServiceDefaults();
}

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient<CubeTimeAnalyzerHttpClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"] ?? "https://localhost:5000/");
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
