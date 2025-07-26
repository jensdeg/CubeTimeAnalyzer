using CubeTimeAnalyzer.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CubeTimeAnalyzer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnalyzeController : ControllerBase
    {
        private readonly ITimeService _timeService;

        public AnalyzeController(ITimeService timeService)
        {
            _timeService = timeService;
        }

        [HttpPost]
        public IActionResult AnalyzeTimes()
        {
            if(_timeService.Times.Count == 0)
            {
                return BadRequest("No times available for analysis. Please import times first.");
            }
            var a05s = _timeService
                .CalculateAllA05()
                .OrderBy(a => a.Average)
                .ToList();

            return Ok(a05s);
        }
    }
}
