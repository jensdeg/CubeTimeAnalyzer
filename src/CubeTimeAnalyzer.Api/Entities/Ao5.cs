namespace CubeTimeAnalyzer.Api.Entities
{
    public class Ao5
    {
        public Ao5(List<Time> times)
        {
            if (times == null || times.Count < 5)
            {
                throw new ArgumentException("At least 5 times are required to calculate Ao5.");
            }
            if(times.Where(times => times.DNF).Count() > 1)
            {
                DNF = true;
                return;
            }
            if (times.Where(times => times.DNF).Count() == 1)
            {
                WorstTime = times.FirstOrDefault(t => t.DNF)!;
            }
            else
            {
                WorstTime = times.FirstOrDefault(t => t.Value == times.Max(t => t.Value))!;
            }
            BestTime = times.FirstOrDefault(t => t.Value == times.Min(t => t.Value))!;

            times.Remove(WorstTime);
            times.Remove(BestTime);
            Times = times;
            Average = times.Average(t => t.Value);
        }
        public double Average { get; set; } = double.MaxValue;

        public Time BestTime { get; set; } = Time.DefaultTime;
        public Time WorstTime { get; set; } = Time.DefaultTime;
        public List<Time> Times { get; set; } = [];

        public bool DNF { get; set; } = false;
     }
}
