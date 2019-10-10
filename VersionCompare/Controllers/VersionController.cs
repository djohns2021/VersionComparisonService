using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Test_Web_App.Controllers

{
    public class CompareVersionsArgs
    {
        public string version1 { get; set; }
        public string version2 { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        private Services.VersionService _versionService;
        public VersionController(Services.VersionService versionService) {
            _versionService = versionService;
        }

        [HttpPost]
        [Route("custom")]
        public string CompareVersions([FromBody] CompareVersionsArgs args)
        {
            var stringCompared = String.Compare(args.version1, args.version2);

            var version1Tokens = args.version1.Split('.');
            var version2Tokens = args.version2.Split('.');

            // What if one is longer than the other?

            if (version1Tokens.Length > version2Tokens.Length)
            {
                return "before";
            }
            else if (version1Tokens.Length < version2Tokens.Length)
            {
                return "after";
            }
            else
            {

            }

            for (var i = 0; i < version1Tokens.Length; i++)
            {
                if (i == version2Tokens.Length)
                {

                }

                var v1Token = Convert.ToInt32(version1Tokens[i]);
                var v2Token = Convert.ToInt32(version2Tokens[i]);

                if (v1Token > v2Token)
                {
                    return "after";
                }
                else if (v1Token < v2Token)
                {
                    return "before";
                }
            }

            return $"{args.version1} {stringCompared}";
        }



        [HttpPost]
        [Route("dotnet")]
        public string CompareDotnetVersions([FromBody] CompareVersionsArgs args)
        {
            return _versionService.CompareDotNetVersions(args.version1, args.version2);
        }
    }
}