namespace CubeTimeAnalyzer.App.models;

public class TimeModel
{
    public double Value { get; set; }

    public string Scramble { get; set; } = string.Empty;

    public DateTimeOffset Date { get; set; }

    public bool DNF { get; set; } = false;
}
