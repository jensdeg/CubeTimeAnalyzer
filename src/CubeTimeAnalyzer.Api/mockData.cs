using CubeTimeAnalyzer.Api.Entities;
using CubeTimeAnalyzer.Api.services;

namespace CubeTimeAnalyzer.Api
{
    public static class MockData
    {
        public static List<Time> GetTimes()
            => [
                new Time(1.2, "scramble", DateTimeOffset.UtcNow),
                new Time(1.3, "scramble", DateTimeOffset.UtcNow),
                new Time(3.8, "scramble", DateTimeOffset.UtcNow),
                new Time(1.4, "scramble", DateTimeOffset.UtcNow, true),
                new Time(2.2, "scramble", DateTimeOffset.UtcNow),
                new Time(1.5, "scramble", DateTimeOffset.UtcNow),
                new Time(1.2, "scramble", DateTimeOffset.UtcNow),
                new Time(2.5, "scramble", DateTimeOffset.UtcNow),
                new Time(6.2, "scramble", DateTimeOffset.UtcNow),
                new Time(1.2, "scramble", DateTimeOffset.UtcNow),
                new Time(7.2, "scramble", DateTimeOffset.UtcNow),
            ];

        public static List<Ao5> GetAo5s()
        {
            var timeservice = new TimeService();
            var times = GetTimes();
            timeservice.Load(times);
            return timeservice.CalculateAllA05();
        }
    }

}
