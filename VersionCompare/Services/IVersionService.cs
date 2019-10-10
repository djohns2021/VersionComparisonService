using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VersionCompare.Services
{
    public interface IVersionService
    {
        /// <summary>
        /// Takes a string and tries to format it as if it were a Version, throws an exception if it cannot.
        /// </summary>
        /// <param name="versionString">The string to try and parse as a version</param>
        /// <returns>A list of integer components of the version string</returns>
        List<int> GetValidVersionParts(string versionString);

        /// <summary>
        /// Compares two generic version strings that can contain a differing length of segments. If they have differing
        /// amounts of segments, and all of the matching segments are equal, then the longer one is considered a higher
        /// if and only if that segment is greater than zero (i.e. 1.0.0.1 > 1.0.0).
        /// </summary>
        /// <param name="ver1">The first Version to check</param>
        /// <param name="ver2"></param>
        /// <returns>A string representing if the first param comes 'before', 'after', or is 'equal' to the second param</returns>
        string CompareGenericVersionStrings(string ver1, string ver2);

        /// <summary>
        /// Compares two dotnet versions to see if the first comes before, after or is equal to the second parameter
        /// </summary>
        /// <param name="ver1">The first Version to check</param>
        /// <param name="ver2">The second Version to check to see if the first comes before, after or is equal to </param>
        /// <returns>A string representing if the first param comes 'before', 'after', or is 'equal' to the second param</returns>
        string CompareVersionStrings(Version ver1, Version ver2);
    }
}
