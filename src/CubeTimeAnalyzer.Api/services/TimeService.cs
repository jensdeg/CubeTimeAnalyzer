using CubeTimeAnalyzer.Api.Entities;
using CubeTimeAnalyzer.Api.Interfaces;

namespace CubeTimeAnalyzer.Api.services
{
    public class TimeService : ITimeService
    {
        public IReadOnlyCollection<Time> Times { get; private set; } = [];

        public void Load(List<Time> times)
        {
            Times = times;
        }   
    }
}
