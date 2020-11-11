dotnet nuget push "src\Language\bin\Release\HaemmerElectronics.SeppPenner.Language.*.nupkg" -s "github" --skip-duplicate
dotnet nuget push "src\Language\bin\Release\HaemmerElectronics.SeppPenner.Language.*.nupkg" -s "nuget.org" --skip-duplicate -k "%NUGET_API_KEY%"
PAUSE