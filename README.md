Kethane Utils
=============

This is a set of scripts for Windows users to simplify tasks while working on the [Kethane Pack](https://github.com/Majiir/Kethane) for [Kerbal Space Program](http://www.kerbalspaceprogram.com/).
If this utility set breaks, please post a bug report on github and I'll fix it as soon as possible.
WARNING: full_build.bat and create_mod_folder.bat delete ModFolder. Do not keep your model and cfg files in there.

Building
--------

1. Copy scripts to Kethane project root folder
2. Download the latest public Kethane release, copy the "Kethane" folder into the Kethane project root folder and rename it to "KethaneRelease"
3. Run build_plugin.bat (Requires .NET Framework 3.5 but not Visual Studio)
4. Run combine_files.bat

Running
-------

After building the mod, it's easy to run it:

1. Copy the folder ModFolder created after building to KSP's GameData folder
2. Run KSP.exe