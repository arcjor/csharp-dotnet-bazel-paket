load(
    "@rules_dotnet//dotnet:defs.bzl",
    "csharp_binary",
    "publish_binary",
)

# bazel run //examples:hello
csharp_binary(
    name = "weatherwithbazel",
    srcs = [
        "Controllers/WeatherForecastController.cs",
        "Program.cs",
        "WeatherForecast.cs",
    ],
    # tags = ["requires-network"],
    project_sdk = "web",
    target_frameworks = ["net7.0"],
    targeting_packs = [
        "@example_deps//microsoft.aspnetcore.app.ref",
        "@example_deps//microsoft.netcore.app.ref",
    ],
    deps = [
        # "@paket.main//serilog.aspnetcore",
    ],
)
