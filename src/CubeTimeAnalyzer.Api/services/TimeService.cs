using CubeTimeAnalyzer.Api.Entities;
using CubeTimeAnalyzer.Api.Interfaces;

namespace CubeTimeAnalyzer.Api.services
{
    public class TimeService : ITimeService
    {
        public IReadOnlyCollection<Time> Times { get; private set; } = [];

        public void Load(List<Time> times)
            => Times = times;
        
        public List<Ao5> CalculateAllA05()
        {
            var a05s = new List<Ao5>();
            if (Times.Count < 5)
            {
                return [];
            }
            for (int i = 0; i < Times.Count; i++)
            {
                var times = Times.Skip(i).Take(5).ToList();
                if (times.Count < 5)
                {
                    continue;
                }
                var a05 = new Ao5(times);
                a05s.Add(a05);
            }
            return a05s;
        }
    }
}
