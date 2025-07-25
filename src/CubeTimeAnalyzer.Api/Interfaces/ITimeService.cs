using CubeTimeAnalyzer.Api.Entities;

namespace CubeTimeAnalyzer.Api.Interfaces
{
    public interface ITimeService
    {
        IReadOnlyCollection<Time> Times { get; }
        void Load(List<Time> times);
    }
}
