using KethaneDiagnostics.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KethaneDiagnostics.Abstractions
{
	class KSP
	{
		// Logger
		Logger logger = new Logger("KSP");

		// KSP Abstracted Properties
		public string RootPath { get; private set; }
		public Version Version { get; private set; }
		public List<ModFolder> ModFolders { get; private set; }

		public KSP(string path)
		{
			RootPath = path;
		}

		public void Load()
		{
			// Make sure the .exe is in the folder
			if (!File.Exists(RootPath + @"\KSP.exe"))
				throw new Exception("KSP.exe could not be found in the selected folder, you might have selected the incorrect folder or forgot to install KSP.");
			logger.Log("KSP.exe Found");

			// Detect the Version
			string v = File.ReadAllLines(RootPath + @"\readme.txt").Where(l => l.StartsWith("Version ")).Select(l => l.Substring(8)).SingleOrDefault();
			Version = new Version(v);
			if (Version > new Version("0.21.1"))
				logger.Log("Version " + v + " is newer then the latest update of this utility!", Level.Warning);
			logger.Log("Version: " + v);

			// Detect all Mod Folders
			logger.BeginBlock("Detecting Mod Folders");
			ModFolders = new List<ModFolder>();
			foreach (string path in Directory.GetDirectories(RootPath + @"\GameData"))
			{
				ModFolders.Add(new ModFolder(path.Substring(RootPath.Length)));
				logger.Log(path.Substring(RootPath.Length + 1) + " Folder Detected");
			}
			logger.EndBlock("Detecting Mod Folders");
		}
	}
}
