dotnet build Language.sln -c Release
xcopy /s .\Language\bin\Release ..\Nuget\Source\
pause