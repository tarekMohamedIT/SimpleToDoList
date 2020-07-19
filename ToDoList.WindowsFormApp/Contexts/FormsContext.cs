using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList.WindowsFormApp.Contexts
{
	public class FormsContext
	{
		public static FormsContext Instance { get; } = new FormsContext();

		public Form CurrentActiveForm { get; set; }

		private FormsContext() { }
	}
}
