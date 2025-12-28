namespace CubeTimeAnalyzer.Api.Core.Entities;

public class Average
{
    public Average(IReadOnlyCollection<Time> times, int averageOf, int excludingAmount)
    {
        if (times == null || times.Count != averageOf)
            throw new ArgumentException($"only accepting {averageOf} times");

        if (excludingAmount % 2 != 0 || excludingAmount >= averageOf)
            throw new ArgumentException($"Excluding amount must be even and less than {averageOf}");

        if (times.Where(Dnf).Count() >= excludingAmount)
            DNF = true;

        Times = times;
        AverageOf = averageOf;
        ExcludingAmount = excludingAmount;
    }

    public int AverageOf { get; }
    public int ExcludingAmount { get; }

    public double Value
        => !DNF
            ? Math.Round(CalculateAverage(Times), 2)
            : double.MaxValue;

    public IReadOnlyCollection<Time> Times { get; set; } = [];

    public Time BestTime
        => Times.FirstOrDefault(t => t.Value == Times.Min(t => t.Value))!;

    public Time WorstTime
    {
        get
        {
            if (Times.Where(Dnf).Count() == 1)
                return Times.FirstOrDefault(Dnf)!;
            else
                return Times.FirstOrDefault(t => t.Value == Times.Max(t => t.Value))!;
        }
    }

    public bool DNF { get; set; } = false;

    private double CalculateAverage(IEnumerable<Time> times)
        => times
            .Select(t => t.Value)
            .Order()
            .Skip(ExcludingAmount / 2).Take(AverageOf - ExcludingAmount)
            .Average();

    private static bool Dnf(Time time) => time.Penalty == Penalty.DNF;
}
