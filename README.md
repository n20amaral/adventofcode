# adventofcode

## Add new projects:
```bash
# create event(year) project
dotnet new classlib -o AoC20xx
dotnet sln add ./AoC20xx/AoC20xx.csproj
dotnet add ./AoC20xx/AoC20xx.csproj reference ./AoC.Common

# create tests project
dotnet new xunit -o AoC20xx.Tests
dotnet sln add ./AoC20xx.Tests/AoC20xx.Tests.csproj
dotnet add ./AoC20xx.Tests/AoC20xx.Tests.csproj reference ./AoC20xx

# add reference to console project
dotnet add ./AoC.Console/AoC.Console.csproj reference ./AoC20xx
```

## Run Console App
```bash
cd AoC.Console && dotnet run 
```

## Run Tests
```bash
dotnet test ./advent-of-code.sln
```