namespace CubeTimeAnalyzer.Api.Entities
{
    public class Ao5
    {
        public Ao5(List<Time> times)
        {
            if (times == null || times.Count != 5)
                throw new ArgumentException("only accepting 5 times");

            if (times.Where(times => times.DNF).Count() > 1)
                DNF = true;

            Times = times;
        }

        public double Average
            => !DNF
                ? Times
                    .Select(t => t.Value)
                    .Order()
                    .Skip(1).Take(3)
                    .Average()
                : double.MaxValue;

        public IReadOnlyCollection<Time> Times { get; set; } = [];
        public Time BestTime
            => Times.FirstOrDefault(t => t.Value == Times.Min(t => t.Value))!;
        public Time WorstTime
        {
            get
            {
                if (Times.Where(t => t.DNF).Count() == 1)
                    return Times.FirstOrDefault(t => t.DNF)!;
                else
                    return Times.FirstOrDefault(t => t.Value == Times.Max(t => t.Value))!;
            }
        }
        public bool DNF { get; set; } = false;
    }
}
