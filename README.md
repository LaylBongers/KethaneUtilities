Kethane Utilities
=================

This is a set of scripts for Windows users to simplify tasks while working on the [Kethane Pack](https://github.com/Majiir/Kethane) for [Kerbal Space Program](http://www.kerbalspaceprogram.com/). If this utility set breaks, please post a bug report on github and I'll fix it as soon as possible.

**WARNING**: create_mod_folder.bat deletes ModFolder. Do not keep your model and cfg files in there.

Building
--------

1. Update References in Visual Studio to Assembly-CSharp and UnityEngine. The DLL files for these can be found in "[KSP Root]\KSP_Data\Managed". After building once you can revert the changes to the project file. (Requires Visual Studio unless you know what you're doing)
2. Copy scripts to Kethane project root folder
3. Download the latest public Kethane release, copy the "Kethane" folder into the Kethane project root folder and rename it to "KethaneRelease"
4. Run build_plugin.bat (Requires .NET Framework 3.5 but not Visual Studio)
5. Run combine_files.bat

Running
-------

After building the mod, it's easy to run it:

1. Copy the folder ModFolder created after building to KSP's GameData folder
3. IMPORTANT: Rename the folder to Kethane
3. Run KSP.exe
