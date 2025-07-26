using CubeTimeAnalyzer.Api.Interfaces;
using CubeTimeAnalyzer.Api.services;
using Microsoft.AspNetCore.Mvc;

namespace CubeTimeAnalyzer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImportController : ControllerBase
    {
        private readonly ITimeService _timeService;

        public ImportController(ITimeService timeService)
        {
            _timeService = timeService;
            //_timeService.Load(MockData.GetTimes());
        }

        [HttpPost]
        public IActionResult ImportTimes(IFormFile file)
        {
            Stream reader = file.OpenReadStream();
            using var streamReader = new StreamReader(reader);
            string content = streamReader.ReadToEnd();
            try
            {
                var times = Parser.Parse(content);
                _timeService.Load(times);
                return Ok("Succesfully imported times");
            }
            catch
            {
                return BadRequest($"Wrong file format, please input a Twisty timer export");
            }
        }
    }
}
