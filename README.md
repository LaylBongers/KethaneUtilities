Kethane Utilities
=================

This is a set of scripts for Windows users to simplify tasks while working on or using the [Kethane Pack](https://github.com/Majiir/Kethane) for [Kerbal Space Program](http://www.kerbalspaceprogram.com/). If this utility set breaks, please post a bug report on github and I'll fix it as soon as possible.

The following projects are included:

1. Kethane Diagnostics
2. Kethane Building Scripts

**WARNING**: create_mod_folder.bat deletes ModFolder. Do not keep your model and cfg files in there.

Kethane Diagnostics
-------------------

Kethane Utilites includes a tool to check basic issues in Kethane. This tool is currently still very basic and early in development. To use it, run KethaneDiagnostics.exe in the folder [KethaneDiagnostics](https://github.com/LaylConway/KethaneUtilities/tree/master/KethaneDiagnostics) and follow instructions. Errors will be marked in red and warnings in yellow.

Kethane Building Scripts
------------------------

Kethane Utilites contains a set of scripts for building Kethane and creating a mod folder fully ready to be used in KSP. The scripts can be found in the folder [KethaneBuild](https://github.com/LaylConway/KethaneUtilities/tree/master/KethaneBuild).

### Building
1. Update References in Visual Studio to Assembly-CSharp and UnityEngine. The DLL files for these can be found in "[KSP Root]\KSP_Data\Managed". After building once you can revert the changes to the project file. (Requires Visual Studio unless you know what you're doing)
2. Copy build_plugin.bat and combine_files.bat scripts to Kethane project root folder
3. Download the latest public Kethane release, copy the "Kethane" folder into the Kethane project root folder and rename it to "KethaneRelease"
4. Run build_plugin.bat (Requires .NET Framework 3.5 but not Visual Studio)
5. Run combine_files.bat

### Running
1. Copy the folder ModFolder created after building to KSP's GameData folder
3. IMPORTANT: Rename the folder to Kethane
3. Run KSP.exe
