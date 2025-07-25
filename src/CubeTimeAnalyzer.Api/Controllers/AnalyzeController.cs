using CubeTimeAnalyzer.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CubeTimeAnalyzer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnalyzeController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(string), 200)]
        public IActionResult AnalyzeTimes([FromBody] TimeSet timeSet)
        {
            return Ok(timeSet);
        }
    }
}
