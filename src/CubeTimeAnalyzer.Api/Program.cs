using CubeTimeAnalyzer.Api;
using CubeTimeAnalyzer.Api.Interfaces;
using CubeTimeAnalyzer.Api.services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddOpenApi();
builder.Services.AddSingleton<ITimeService, TimeService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    if (builder.Configuration.GetValue<bool>("EnableMockData"))
    {
        var timeService = app.Services.GetRequiredService<ITimeService>();
        timeService.LoadTimes(MockData.GetTimes());
    }
    app.MapOpenApi();
}
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
