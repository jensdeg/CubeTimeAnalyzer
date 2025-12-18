using CubeTimeAnalyzer.Api.Core.Entities;
using CubeTimeAnalyzer.Api.Core.Interfaces;
using CubeTimeAnalyzer.Api.Core.Shared;
using CubeTimeAnalyzer.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CubeTimeAnalyzer.Api.Core.services;

public class TimeService(CubeTimeAnalyzerContext context) : ITimeService
{
    private readonly CubeTimeAnalyzerContext _context = context;

    public async Task<IReadOnlyCollection<Time>> GetTimes(CubeType type)
        => await _context.Times
            .Where(t => t.CubeType == type)
            .ToListAsync();

    public async Task LoadTimes(List<Time> times)
    {
        var currentTimes = _context.Times
            .Where(t => t.CubeType == times.First().CubeType)
            .ToList();

        var newTimes = times
            .Where(t => !currentTimes.Any(ct => ct.Equals(t)))
            .ToList();

        if (newTimes.Count == 0) return;

        await _context.Times.AddRangeAsync(times);
        await _context.SaveChangesAsync();
    }

    public static IReadOnlyCollection<Average> CalculateAverages(
        List<Time> times, int averageOf, int excludeAmount)
    {
        var averages = new List<Average>();
        if (times.Count < averageOf)
        {
            return [];
        }
        for (int i = 0; i < times.Count; i++)
        {
            var TimeSet = times.Skip(i).Take(averageOf).ToList();
            if (TimeSet.Count < averageOf)
            {
                continue;
            }
            averages.Add(new Average(TimeSet, averageOf, excludeAmount));
        }
        return averages;
    }
}
