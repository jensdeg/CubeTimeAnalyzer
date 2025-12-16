using CubeTimeAnalyzer.Api.Core.Interfaces;
using CubeTimeAnalyzer.Api.Core.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CubeTimeAnalyzer.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AnalyzeController(ITimeService timeService) : ControllerBase
{
    [HttpGet("Averages")]
    public ActionResult<GetAverageResponse> GetAverages([FromBody] GetAverageRequest request)
    {
        var times = timeService.GetTimes().ToList();

        if (times.Count == 0)
            return BadRequest("No times available for analysis");

        var averages = timeService
            .CalculateAverages(times, request.AverageOf, request.ExcludingAmount)
            .OrderBy(average => average.Value)
            .ToList();

        return Ok(new GetAverageResponse { Averages = averages });
    }
}