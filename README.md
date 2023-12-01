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


Phase 3:
Switch the non-bazel weather app to use paket as per the official steps from https://fsprojects.github.io/Paket/

Commands:
`dotnet new tool-manifest`
`dotnet tool install paket` (Adds paket to `.config/dotnet-tools.json`)
`dotnet tool restore` (Makes the `paket` command available)
`dotnet paket init` (`Creates the paket.dependencies file`)
Create `build.sh`
`chmod 755 build.sh`
Add Serilog.AspNetCore to `paket.dependencies`
Create `paket.references` in `Weathernobazel` and add Serilog.AspNetCore
`dotnet paket install`
Remove the old nuget based reference to serilog from `Weathernobazel/Weathernobazel.csproj`
`./build.sh Weathernobazel/Weathernobazel.csproj`

Now when we `dotnet run --project Weathernobazel/Weathernobazel.csproj` we are using a project built with paket based dependencies.


Phase 4:
Switch the bazel weather app to use paket with paket2bazel as per `https://github.com/bazelbuild/rules_dotnet/blob/v0.12.0/tools/paket2bazel/README.md`

Commands:
Add the `WORKSPACE` snippet to load paket2bazel_dependencies.
`mkdir deps`
`bazel run @rules_dotnet//tools/paket2bazel:paket2bazel.exe -- --dependencies-file $(pwd)/paket.dependencies  --output-folder $(pwd)/deps`
Add the `WORKSPACE` snippet to load packet.bzl.
