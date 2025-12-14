using CubeTimeAnalyzer.Api.Entities;
using CubeTimeAnalyzer.Api.Interfaces;

namespace CubeTimeAnalyzer.Api.services;

public class TimeService : ITimeService
{
    private List<Time> _times = [];

    public IReadOnlyCollection<Time> GetTimes()
        => _times.AsReadOnly();

    public void LoadTimes(List<Time> times)
        => _times = times;

    public IReadOnlyCollection<Average> CalculateAverages(
        List<Time> times, int averageOf, int excludeAmount)
    {
        var averages = new List<Average>();
        if (times.Count < averageOf)
        {
            return [];
        }
        for (int i = 0; i < times.Count; i++)
        {
            var TimeSet = times.Skip(i).Take(averageOf).ToList();
            if (TimeSet.Count < averageOf)
            {
                continue;
            }
            averages.Add(new Average(TimeSet, averageOf, excludeAmount));
        }
        return averages;
    }
}
