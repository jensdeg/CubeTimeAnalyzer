using CubeTimeAnalyzer.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CubeTimeAnalyzer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnalyzeController(ITimeService timeService) : ControllerBase
    {
        [HttpGet("Averages")]
        public IActionResult GetAverages()
        {
            if(timeService.Times.Count == 0)
                return BadRequest("No times available for analysis. Please import times first.");

            var a05s = timeService
                .CalculateAllA05()
                .OrderBy(a => a.Average)
                .ToList();

            return Ok(a05s);
        }
    }
}
