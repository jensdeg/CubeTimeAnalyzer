using CubeTimeAnalyzer.Api.Core.Entities;
using CubeTimeAnalyzer.Api.Core.services;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace CubeTimeAnalyzer.Api.Controllers;

[ApiController]
[Route("[controller]")]
public partial class ScrambleController : ControllerBase
{
    readonly ScrambleService ScrambleService = new();

    [HttpGet]
    public ActionResult<Cube> GetScrambledCube([FromBody] string Scramble)
    {
        if (string.IsNullOrEmpty(Scramble)) return BadRequest("No Scramble provided");
        if (!ScrambleRegex().IsMatch(Scramble)) return BadRequest($"Not a valid Scramble \nRegex: '{ScrambleRegex()}'");

        return ScrambleService.GetScrambledCube(Scramble);
    }

    [GeneratedRegex("^(?:[URLFBD](?:2|')?)(?: [URLFBD](?:2|')?)*$", RegexOptions.Compiled)]
    private static partial Regex ScrambleRegex();
}
