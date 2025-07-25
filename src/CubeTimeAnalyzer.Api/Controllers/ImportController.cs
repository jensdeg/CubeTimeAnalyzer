using CubeTimeAnalyzer.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CubeTimeAnalyzer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImportController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(TimeSet), 200)]
        public IActionResult ImportTimes(IFormFile file)
        {
            Stream reader = file.OpenReadStream();
            using var streamReader = new StreamReader(reader);
            string content = streamReader.ReadToEnd();
            try
            {
                var timeset = TimeSet.Parse(content);
                return Ok(timeset);
            }
            catch
            {
                return BadRequest($"Wrong file format, please input a Twisty timer export");
            }
        }
    }
}
