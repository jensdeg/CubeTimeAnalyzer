using CubeTimeAnalyzer.Api.Core.Entities;
using CubeTimeAnalyzer.Api.Core.Interfaces;

namespace CubeTimeAnalyzer.Api.Core.services;

public class MockTimeService : ITimeService
{
    public IReadOnlyCollection<Time> GetTimes()
    {
        var random = new Random();
        var times = new List<Time>();
        for (int i = 0; i < random.Next(50, 100); i++)
        {
            var time = Math.Round(random.Next(20, 30) + random.NextDouble(), 2);
            times.Add(new Time(time, "randomscramble", DateTimeOffset.Now, CubeType.Cube3x3));
        }
        return times.AsReadOnly();
    }

    public IReadOnlyCollection<Average> CalculateAverages(List<Time> _, int AverageOf, int ExcludeAmount)
    {
        var timeservice = new TimeService();
        var times = GetTimes().ToList();
        return timeservice.CalculateAverages(times, AverageOf, ExcludeAmount);
    }

    public void LoadTimes(List<Time> times)
    {
        // nothing
    }
}
