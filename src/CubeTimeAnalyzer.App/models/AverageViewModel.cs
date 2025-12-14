using CubeTimeAnalyzer.Api.Entities;

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
                DNF = average.BestTime.DNF
            },
            WorstTime = new TimeModel
            {
                Value = average.WorstTime.Value,
                Scramble = average.WorstTime.Scramble,
                Date = average.WorstTime.Date,
                DNF = average.WorstTime.DNF
            },
            Times = average.Times.Select(t => new TimeModel
            {
                Value = t.Value,
                Scramble = t.Scramble,
                Date = t.Date,
                DNF = t.DNF
            }).ToList(),
            DNF = average.DNF
        };
    }
}
