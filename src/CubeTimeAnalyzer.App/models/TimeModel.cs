using CubeTimeAnalyzer.Api.Core.Entities;

namespace CubeTimeAnalyzer.App.models;

public class TimeModel
{
    public double Value { get; set; }

    public string Scramble { get; set; } = string.Empty;

    public DateTimeOffset Date { get; set; }

    public Penalty Penalty { get; set; }
}
