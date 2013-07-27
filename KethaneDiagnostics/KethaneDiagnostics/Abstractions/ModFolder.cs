using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KethaneDiagnostics.Abstractions
{
	class ModFolder
	{
		public string Path { get; private set; }

		public ModFolder(string path)
		{
			Path = path;
		}
	}
}
