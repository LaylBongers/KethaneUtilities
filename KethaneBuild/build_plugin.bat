@echo off

REM ======== Run MSBuild to Build the Plugin DLL ========
echo Running MSBuild...
C:\Windows\Microsoft.NET\Framework\v3.5\msbuild /p:Configuration=Release /toolsversion:3.5 Plugin\Kethane.sln
echo.
echo If no errors occured the Mod Folder has been successfully created!
pause