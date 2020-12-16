var target = Argument("target", "Test");
var configuration = Argument("configuration", "Debug");
var buildNumber = Argument<string>("build-number", null);

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    // .WithCriteria(c => HasArgument("rebuild"))
    .Does(() =>
{
    CleanDirectory($"./out");
});

Task("Build")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DotNetCoreBuild("./case-extensions.sln", new DotNetCoreBuildSettings
    {
        Configuration = configuration,
    });
});

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
{
    DotNetCoreTest("./case-extensions.sln", new DotNetCoreTestSettings
    {
        Configuration = configuration,
        Framework = "net5.0",
        NoBuild = true,
    });
});

Task("Pack")
    .IsDependentOn("Build")
    .Does(() =>
{
    var msBuildSettings = new DotNetCoreMSBuildSettings()
        .WithProperty("BuildNumber", buildNumber);

    DotNetCorePack("./case-extensions.sln", new DotNetCorePackSettings
    {
        Configuration = configuration,
        OutputDirectory = "./out/",
        NoBuild = true,
        MSBuildSettings = msBuildSettings,
    });
});

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);