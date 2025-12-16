using CubeTimeAnalyzer.Api.Core.Interfaces;
using CubeTimeAnalyzer.Api.Core.services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddOpenApi();

if (builder.Configuration.GetValue<bool>("EnableMockData"))
{
    builder.Services.AddSingleton<ITimeService, MockTimeService>();
}
else
{
    builder.Services.AddSingleton<ITimeService, TimeService>();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
