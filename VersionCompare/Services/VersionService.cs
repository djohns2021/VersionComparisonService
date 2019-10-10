using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Web_App.Services
{
    public class VersionService
    {
        public VersionService() { }

        public string CompareDotNetVersions(string ver1, string ver2)
        {
            var dotnetVer1 = Version.Parse(ver1);
            var dotnetVer2 = Version.Parse(ver2);

            if (dotnetVer1 > dotnetVer2)
            {
                return "after";
            }
            else if (dotnetVer1 < dotnetVer2)
            {
                return "before";
            }

            return "equal";
        }
    }
}
