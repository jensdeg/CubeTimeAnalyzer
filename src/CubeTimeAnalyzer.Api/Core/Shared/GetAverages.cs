using CubeTimeAnalyzer.Api.Core.Entities;

namespace CubeTimeAnalyzer.Api.Core.Shared;

public sealed record GetAverageRequest
{
    public required int AverageOf { get; init; }
    public required int ExcludingAmount { get; init; }
    public required CubeType CubeType { get; init; }
}

public sealed record GetAverageResponse
{
    public required List<Average> Averages { get; init; }
}
