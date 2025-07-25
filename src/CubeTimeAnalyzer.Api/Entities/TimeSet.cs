using System.Runtime.CompilerServices;

namespace CubeTimeAnalyzer.Api.Entities
{
    public class TimeSet
    {
        public TimeSet(List<Time> times) 
        {
            Times = times;
        }
        public List<Time> Times { get; set; } = new List<Time>();

        public static TimeSet Parse(string content)
        {
            var times = new List<Time>();
            var lines = content.Split('\n');
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var parts = line.Split(';');

                double timeValue = double.Parse(parts[0].Trim('"').Replace('.',','));
                string scramble = parts[1].Trim('"');
                string dateString = parts[2].Trim('"');
                
                var time = new Time(timeValue, scramble, DateTimeOffset.Parse(dateString));
                if (parts.Length > 3) // dnf is stored after the date, so if there are more than 3 parts, it's a DNF
                {
                    time.DNF = true;
                }
                times.Add(time);
            }
            return new TimeSet(times);
        }
    }
}
