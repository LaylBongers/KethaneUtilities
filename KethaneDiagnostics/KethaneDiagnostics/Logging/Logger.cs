using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KethaneDiagnostics.Logging
{
	public enum Level
	{
		Info,
		Warning,
		Error,
		Pass,
		Highlight
	}

	static class LevelExtensions
	{
		public static void SetConsoleColor(this Level level)
		{
			switch (level)
			{
				case Level.Info:
					Console.ForegroundColor = ConsoleColor.White;
					break;
				case Level.Warning:
					Console.ForegroundColor = ConsoleColor.Yellow;
					break;
				case Level.Error:
					Console.ForegroundColor = ConsoleColor.Red;
					break;
				case Level.Pass:
					Console.ForegroundColor = ConsoleColor.Green;
					break;
				case Level.Highlight:
					Console.ForegroundColor = ConsoleColor.Cyan;
					break;
			}
		}
	}

	public class Logger
	{
		// Static Convenience Functions, for Debugging //

		/// <summary>
		/// Uses reflection to construct a logging message with text as message.
		/// </summary>
		/// <param name="text">The Message to be Logged</param>
		public static void DebugLog(string text)
		{
			DebugLog(text, Level.Info);
		}

		public static void DebugLog(string text, Level level)
		{
			StackTrace stackTrace = new StackTrace();
			StackFrame frame = stackTrace.GetFrame(2);

			level.SetConsoleColor();
			Console.WriteLine("[Debug] [{0}:{1}] {2}",
				frame.GetMethod().ReflectedType,
				frame.GetMethod().Name,
				text);
		}

		// Actual Class //

		/// <summary>Used for Displaying Blocks of Operations Like Loading</summary>
		public static int Indention { get; private set; }

		/// <summary>Tag to be Used While Logging</summary>
		private string tagText;

		public Logger(string tag) { tagText = tag; }

		public void BeginBlock(string blockName)
		{
			Log(blockName + "...");
			Indention++;
		}

		public void EndBlock(string blockName)
		{
			Indention--;
			Log("Finished " + blockName);
		}

		
		public void ResetIndention()
		{
			Indention = 0;
		}

		/// <summary>
		/// Constructs a Logging Message
		/// </summary>
		/// <param name="text">The Message to be Logged</param>
		public void Log(string text)
		{
			Log(text, Level.Info);
		}

		/// <summary>
		/// Constructs a Logging Message
		/// </summary>
		/// <param name="text">The Message to be Logged</param>
		/// <param name="level">The Level of the Message</param>
		public void Log(string text, Level level)
		{
			level.SetConsoleColor();
			Console.WriteLine("{0}[{1}] {2}",
				"".PadRight(Indention, ' '),
				tagText,
				text);
		}

		public void LogException(Exception ex, Level level)
		{
#if DEBUG
			Log(
				String.Format("[Exception] {0}\n{1}", ex.Message, ex.StackTrace),
				level);
#else
			Log(
				String.Format("[Exception] {0}", ex.Message),
				level);
#endif
		}
	}
}
