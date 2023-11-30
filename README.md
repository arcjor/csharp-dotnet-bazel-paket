# csharp-dotnet-bazel-paket
A repository which walks through the configuration of a project with bazel and paket in steps, guided primarily by https://github.com/bazelbuild/rules_dotnet/tree/v0.12.0/docs

The v0.12.0 release was selected because originally the default nuget path was evaluated, which is not present in the next release.
In a latter increment the project will be updated to depend on latest.

Phase 1:
Install devcontainer and pain of Aspnetcore projects, one built with `dotnet build` and one with bazel. Neither use paket for dependencies yet.

In this increment we can build or run the non-bazel project with `dotnet build Weathernobazel/Weathernobazel.csproj` or `dotnet run --project Weathernobazel/Weathernobazel.csproj` respectively.

We can build or run the bazel project with `bazel build //Weatherwithbazel:weatherwithbazel` or `bazel build //Weatherwithbazel:weatherwithbazel`.


Phase 2:
Include the serilog dependency in the non-bazel project, resolved through nuget. Make the app say 'HEY' when you send a request.

(Add serilog with `dotnet add package Serilog.AspNetCore` from with the `Weathernobazel` directory. Uncomment serilog lines.)


