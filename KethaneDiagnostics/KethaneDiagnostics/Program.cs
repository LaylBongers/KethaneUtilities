using KethaneDiagnostics.Abstractions;
using KethaneDiagnostics.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KethaneDiagnostics
{
	class MainWindow
	{
		// Logger
		static Logger logger = new Logger("MainWindow");

		[STAThread]
		static void Main(string[] args)
		{
			try {
				MainWindow mainWindow = new MainWindow();
				mainWindow.Run();
			}
			catch (Exception e)
			{
				logger.ResetIndention();
				logger.LogException(e, Level.Error);
			}

			// Make sure the user knows the utility is done.
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("\nKethaneDiagnostics finished running.");
			Console.WriteLine("Please remember that this tool stops as soon as an error occurs.");
			Console.WriteLine("A problem may not have been detected as a result of this.");
			Console.WriteLine("Some unknown or hard to detect problems may also not have been detected.");
			Console.WriteLine("Press enter to exit...");
			while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
		}

		// Abstractions
		KSP ksp;
		Kethane kethane;

		public void Run()
		{
			/// Load in and scan KSP's files ///
			logger.BeginBlock("Scanning KSP");
			
			// Ask user to browse to the KSP folder
			FolderBrowserDialog kspFolderDialog = new FolderBrowserDialog();
			kspFolderDialog.RootFolder = Environment.SpecialFolder.ProgramFilesX86;
			kspFolderDialog.ShowNewFolderButton = false;
			kspFolderDialog.Description = "Please select the KSP Root folder. This is the folder containing \"KSP.exe\". If you use steam this folder will be in \"Steam\\SteamApps\\common\".";
			DialogResult kspFolderResult = kspFolderDialog.ShowDialog();
			if(kspFolderResult != DialogResult.OK)
				throw new Exception("User closed KSP browse dialog.");

			// Load and Scan the KSP Installation
			ksp = new KSP(kspFolderDialog.SelectedPath);
			ksp.Load();

			logger.EndBlock("Scanning KSP");

			/// Load in and scan Kethane's files ///
			logger.BeginBlock("Scanning Kethane");

			kethane = new Kethane(ksp);
			kethane.Load();

			logger.EndBlock("Scanning Kethane");
		}
	}
}
