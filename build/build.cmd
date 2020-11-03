cd ..\src
rd /S /Q bin
rd /S /Q obj
dotnet clean
dotnet publish -r win-x64 -c Release