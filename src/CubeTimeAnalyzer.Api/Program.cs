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

app.MapControllers();

app.Run();
