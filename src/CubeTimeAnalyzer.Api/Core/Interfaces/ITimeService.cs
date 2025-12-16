using CubeTimeAnalyzer.Api.Core.Entities;

namespace CubeTimeAnalyzer.Api.Core.Interfaces;

public interface ITimeService
{
    IReadOnlyCollection<Time> GetTimes();

    void LoadTimes(List<Time> times);

    IReadOnlyCollection<Average> CalculateAverages(
        List<Time> times,
        int AverageOf,
        int ExcludeAmount);
}
