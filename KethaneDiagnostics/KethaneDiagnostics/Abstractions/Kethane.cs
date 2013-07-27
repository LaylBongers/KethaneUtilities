using KethaneDiagnostics.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KethaneDiagnostics.Abstractions
{
	class Kethane
	{
		// Logger
		Logger logger = new Logger("KSP");

		// Abstractions
		public KSP KSP { get; set; }

		public Kethane(KSP ksp)
		{
			KSP = ksp;
		}

		public void Load()
		{
			ModFolder kethaneFolder = null;
			foreach(ModFolder folder in KSP.ModFolders)
			{
				if (folder.Path.Contains("Kethane"))
				{
					kethaneFolder = folder;
					break;
				}
			}
			if (kethaneFolder == null)
				throw new Exception("Kethane folder could not be found in GameData, you installed Kethane incorrectly.");
			logger.Log("Kethane Folder Found");
		}
	}
}
