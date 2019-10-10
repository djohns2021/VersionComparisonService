using System;
using System.Linq;
using System.Collections.Generic;
using VersionCompare.Services;

namespace VersionCompare.Services
{
    public class VersionService: IVersionService
    {
        public VersionService() { }

        public List<int> GetValidVersionParts(string versionString)
        {
            var verTokens = versionString.Split('.');
            return verTokens.Select(token => Convert.ToInt32(token)).ToList();
        }

        public string CompareVersionStrings(Version ver1, Version ver2)
        {
            if (ver1 > ver2)
            {
                return "after";
            }
            else if (ver1 < ver2)
            {
                return "before";
            }

            return "equal";
        }

        public string CompareGenericVersionStrings(string ver1, string ver2)
        {
            var version1Tokens = GetValidVersionParts(ver1);
            var version2Tokens = GetValidVersionParts(ver2);

            var minLength = Math.Min(version1Tokens.Count(), version2Tokens.Count());

            for (var i = 0; i < minLength; i++)
            {
                if (version1Tokens[i] < version2Tokens[i])
                {
                    return "before";
                }
                else if (version1Tokens[i] > version2Tokens[i])
                {
                    return "after";
                }
            }

            // If we get to this point, we've reach the end of the min length so lets check the max
            // This is assuming that 1.0.0 < 1.0.0.1, while this doesnt follow traditional semver,
            // someone might be using something like this somewhere ¯\_(ツ)_/¯
            if (version1Tokens.Count() > minLength)
            {
                for (var i = minLength; i < version1Tokens.Count(); i++)
                {
                    if (version1Tokens[i] > 0)
                    {
                        return "after";
                    }
                }
            } else if (version2Tokens.Count() > minLength)
            {
                for (var i = minLength; i < version2Tokens.Count(); i++)
                {
                    if(version2Tokens[i] > 0)
                    {
                        return "before";
                    }
                }
            }


            // They really, truely are
            return "equal";
        }
    }
}
