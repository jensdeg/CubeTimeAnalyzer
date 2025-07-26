using CubeTimeAnalyzer.Api.services;
using CubeTimeAnalyzer.Api.Interfaces;
using CubeTimeAnalyzer.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSingleton<ITimeService, TimeService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();
app.UseAuthorization();

var timeservice = app.Services.GetRequiredService<ITimeService>();
timeservice.Load(mockData.GetMockTimes());
var a05s = timeservice.CalculateAllA05();
foreach(var a05 in a05s)
{
    Console.WriteLine(a05);
}

app.MapControllers();

app.Run();
