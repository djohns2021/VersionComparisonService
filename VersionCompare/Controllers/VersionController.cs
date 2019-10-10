using System;
using Microsoft.AspNetCore.Mvc;
using VersionCompare.Services;

namespace VersionCompare.Controllers

{
    /// <summary>
    /// The arguments for the /generic endpoint
    /// TODO: This should probably be moved or cleaned up or something - DAJ 20191009
    /// </summary>
    public class CompareVersionsArgs
    {
        public string version1 { get; set; }
        public string version2 { get; set; }
    }

    /// <summary>
    /// The arguments for the /dotnet endpoint
    /// TODO: This should probably be moved or cleaned up or something - DAJ 20191009
    /// </summary>
    public class CompareDotNetVersionArgs
    {
        public Version version1 { get; set; }
        public Version version2 { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        private IVersionService _versionService;
        public VersionController(IVersionService versionService) {
            _versionService = versionService;
        }

        [HttpPost("generic")]
        public IActionResult CompareGenericVersions([FromBody] CompareVersionsArgs args)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _versionService.CompareGenericVersionStrings(args.version1, args.version2);
            return Ok(result);
        }

        [HttpPost("dotnet")]
        public IActionResult CompareDotnetVersions([FromBody] CompareDotNetVersionArgs args)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _versionService.CompareVersionStrings(args.version1, args.version2);
            return Ok(result);
        }
    }
}