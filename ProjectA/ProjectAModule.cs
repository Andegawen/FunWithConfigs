using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA
{
    public class ProjectAModule
	{
		public void kiki()
		{
			var z = Assembly.GetExecutingAssembly().Location;
		}
    }
}
