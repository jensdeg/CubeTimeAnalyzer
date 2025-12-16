namespace CubeTimeAnalyzer.Api.Core.Entities;

public class Time
{
    public Time(double value, string scramble, DateTimeOffset date, bool dnf = false)
    {
        Value = value;
        Scramble = scramble;
        Date = date;
        DNF = dnf;
    }

    public double Value { get; set; }

    public string Scramble { get; set; }

    public DateTimeOffset Date { get; set; }

    public bool DNF { get; set; }
}
