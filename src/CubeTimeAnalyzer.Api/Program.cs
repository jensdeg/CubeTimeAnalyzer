using CubeTimeAnalyzer.Api;
using CubeTimeAnalyzer.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddNewtonsoftJson();

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddCore(builder.Configuration)
    .AddOpenApi();

if (args.Contains("--Aspire"))
{
    builder.AddServiceDefaults();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    if (args.Contains("--Aspire"))
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<CubeTimeAnalyzerContext>();
        var strat = context.Database.CreateExecutionStrategy();
        strat.Execute(context.Database.Migrate);
    }
}
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
