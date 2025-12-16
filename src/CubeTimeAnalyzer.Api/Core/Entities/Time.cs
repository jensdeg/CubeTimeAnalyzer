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

    public double Value { get; set; }

    public string Scramble { get; set; }

    public DateTimeOffset Date { get; set; }

    public bool DNF { get; set; } = false;

    public CubeType CubeType { get; set; }
}

public enum CubeType
{
    Cube2x2,
    Cube3x3,
    Cube4x4,
    Cube5x5,
    Cube6x6,
    Cube7x7,
    Skewb,
    Megaminx,
    Pyraminx,
    Square1,
    Clock
}
