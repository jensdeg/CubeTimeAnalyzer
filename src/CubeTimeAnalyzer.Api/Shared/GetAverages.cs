using CubeTimeAnalyzer.Api.Entities;

namespace CubeTimeAnalyzer.Api.Shared;

public sealed record GetAverageRequest
{
    public required int AverageOf { get; init; }
    public required int ExcludingAmount { get; init; }
}

public sealed record GetAverageResponse
{
    public required List<Average> Averages { get; init; }
}
