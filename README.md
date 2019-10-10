# Version Compare Webapp for Fetch
This application provides functionality to see if the first provided versioning string is before, after, or equal to the
second provided version string.

There are two endpoints that can be hit with the same body to check this:

The first endpoint makes use of .NET's built
in [Version](https://docs.microsoft.com/en-us/dotnet/api/system.version?view=netframework-4.8) class as it is both a fast
and easy solution, however it comes with a caveat. The built in Version class requires the passed in version strings to
be 2 to 4 segments long as their version is defined as `major.minor[.build[.revision]]`, where build and revision are
optional.

The second endpoint is more of a custom solution that does not have the same constraints as the Version class. It will
accept any string, provided it is only composed of numbers and periods. It then treats the string as version number components
with the left most component as the most significant with the following (right to left) segments less significant the further
right your traverse. 

## How To Run

The primary way to run this application is through Docker. If you have Docker, you can navigate to the base folder of
this project and run the following commands to build and then run the app:

```
docker build -t versioncompare .
docker run -d -p 8000:80 --name versioncomparedockerapp versioncompare
```

It can also be ran through any IDE that supports .NET core v2.2. The easiest way is to load the solution and then build with the
IDE. The default port should be set to :8000 when ran this way.
