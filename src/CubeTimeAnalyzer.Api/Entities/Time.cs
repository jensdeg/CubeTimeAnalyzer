namespace CubeTimeAnalyzer.Api.Entities
{
    public class Time
    {
        public Time(double time, string scramble, DateTimeOffset date)
        {
            Value = time;
            Scramble = scramble;
            Date = date;
        }
        public Time(double time, string scramble, DateTimeOffset date, bool dnf)
        {
            Value = time;
            Scramble = scramble;
            Date = date;
            DNF = dnf;
        }

        public double Value { get; set; }

        public string Scramble { get; set; }

        public DateTimeOffset Date { get; set; }

        public bool DNF { get; set; } = false;

        public static Time DefaultTime 
            => new(double.MaxValue, string.Empty, DateTimeOffset.MaxValue);
    }
}
