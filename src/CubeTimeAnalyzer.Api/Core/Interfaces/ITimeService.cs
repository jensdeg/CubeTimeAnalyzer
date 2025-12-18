using CubeTimeAnalyzer.Api.Core.Entities;
using CubeTimeAnalyzer.Api.Core.Shared;

namespace CubeTimeAnalyzer.Api.Core.Interfaces;

public interface ITimeService
{
    Task<IReadOnlyCollection<Time>> GetTimes(CubeType type);

    Task LoadTimes(List<Time> times);
}
