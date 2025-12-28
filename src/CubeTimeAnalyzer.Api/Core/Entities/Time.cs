using CubeTimeAnalyzer.Api.Core.Shared;

namespace CubeTimeAnalyzer.Api.Core.Entities;

public class Time
{
    public int TimeId { get; }

    public double Value { get; set; }

    public string Scramble { get; set; }

    public DateTimeOffset Date { get; set; }

    public CubeType CubeType { get; set; }

    public string Category { get; set; }

    public Penalty Penalty { get; set; } = Penalty.None;

    public string? Comment { get; set; }


    public override bool Equals(object? obj)
        => obj is Time time &&
           Value == time.Value &&
           Scramble == time.Scramble &&
           Date == time.Date &&
           Penalty == time.Penalty &&
           CubeType == time.CubeType &&
           Category == time.Category &&
           Comment == time.Comment;

    public override int GetHashCode()
        => HashCode.Combine(Value, Scramble, Date, Penalty, CubeType, Category, Comment);
}

public enum Penalty
{
    None = default,
    Plus2 = 1,
    DNF = 2,
}
