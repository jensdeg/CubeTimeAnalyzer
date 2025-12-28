using CubeTimeAnalyzer.Api.Core.Entities;

namespace CubeTimeAnalyzer.App.models;

public class AverageViewModel
{
    public double Value { get; set; }

    public required TimeModel BestTime { get; set; }

    public required TimeModel WorstTime { get; set; }

    public List<TimeModel> Times { get; set; } = [];

    public bool DNF { get; set; } = false;
}

public static class AverageViewModelExtensions
{
    public static AverageViewModel ToViewModel(this Average average)
    {
        return new AverageViewModel
        {
            Value = average.Value,
            BestTime = new TimeModel
            {
                Value = average.BestTime.Value,
                Scramble = average.BestTime.Scramble,
                Date = average.BestTime.Date,
                Penalty = average.BestTime.Penalty
            },
            WorstTime = new TimeModel
            {
                Value = average.WorstTime.Value,
                Scramble = average.WorstTime.Scramble,
                Date = average.WorstTime.Date,
                Penalty = average.WorstTime.Penalty
            },
            Times = average.Times.Select(t => new TimeModel
            {
                Value = t.Value,
                Scramble = t.Scramble,
                Date = t.Date,
                Penalty = t.Penalty
            }).ToList(),
            DNF = average.DNF
        };
    }
}
