using CubeTimeAnalyzer.Api.Entities;

namespace CubeTimeAnalyzer.Api.services
{
    public class TimeService
    {
        public IReadOnlyCollection<Time> Times = [];

        public void Load(List<Time> times)
        {
            Times = times;
        }   
    }
}
