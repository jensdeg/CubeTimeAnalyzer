using CubeTimeAnalyzer.Api.Entities;
using CubeTimeAnalyzer.Api.services;

namespace CubeTimeAnalyzer.Api;

public static class MockData
{
    public static List<Time> GetTimes()
    {
        var random = new Random();
        var times = new List<Time>();
        for (int i = 0; i < random.Next(50, 100); i++)
        {
            var time = Math.Round(random.Next(20, 30) + random.NextDouble(), 2);
            times.Add(new Time(time, "randomscramble", DateTimeOffset.Now));
        }
        return times;
    }

    public static IReadOnlyCollection<Average> GetAverages()
    {
        var timeservice = new TimeService();
        var times = GetTimes();
        return timeservice.CalculateAverages(times, 5, 2);
    }
}
