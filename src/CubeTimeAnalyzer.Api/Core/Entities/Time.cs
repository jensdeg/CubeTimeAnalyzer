using CubeTimeAnalyzer.Api.Core.Shared;

namespace CubeTimeAnalyzer.Api.Core.Entities;

public class Time
{
    public Time(double value, string scramble, DateTimeOffset date, CubeType cubeType)
    {
        Value = value;
        Scramble = scramble;
        Date = date;
        CubeType = cubeType;
    }
    public int TimeId { get; }

    public double Value { get; set; }

    public string Scramble { get; set; }

    public DateTimeOffset Date { get; set; }

    public bool DNF { get; set; } = false;

    public CubeType CubeType { get; set; }

    public override bool Equals(object? obj)
        => obj is Time time &&
           Value == time.Value &&
           Scramble == time.Scramble &&
           Date == time.Date &&
           DNF == time.DNF &&
           CubeType == time.CubeType;

    public override int GetHashCode()
        => HashCode.Combine(Value, Scramble, Date, DNF, CubeType);
}
