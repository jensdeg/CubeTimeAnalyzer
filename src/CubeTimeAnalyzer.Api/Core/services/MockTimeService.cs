using CubeTimeAnalyzer.Api.Core.Entities;
using CubeTimeAnalyzer.Api.Core.Interfaces;
using CubeTimeAnalyzer.Api.Core.Shared;
using Microsoft.EntityFrameworkCore;

namespace CubeTimeAnalyzer.Api.Core.services;

public class MockTimeService : ITimeService
{
    public Task<IReadOnlyCollection<Time>> GetTimes(CubeType type)
    {
        var random = new Random();
        var times = new List<Time>();
        for (int i = 0; i < random.Next(50, 100); i++)
        {
            var time = Math.Round(random.Next(20, 30) + random.NextDouble(), 2);
            times.Add(new Time
            {
                Value = time,
                Scramble = "randomscramble",
                Category = "normal",
                CubeType = type,
                Date = DateTimeOffset.Now
            });
        }
        IReadOnlyCollection<Time> readOnlyTimes = times.AsReadOnly();
        return Task.FromResult(readOnlyTimes);
    }

    public IReadOnlyCollection<Average> CalculateAverages(List<Time> _, int AverageOf, int ExcludeAmount)
    {
        var times = GetTimes(CubeType.Cube3x3)
            .GetAwaiter().GetResult().ToList();

        return TimeService
            .CalculateAverages(times, AverageOf, ExcludeAmount);
    }

    public async Task LoadTimes(List<Time> times)
    {
        await Task.CompletedTask; // nothing
    }
}
