using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoList.Core.Persistence.DataProviders;
using ToDoList.WindowsFormApp.Models;

namespace ToDoList.WindowsFormApp.Contexts
{
	public class FormsContext
	{
		public static FormsContext Instance { get; } = new FormsContext();

		public Form CurrentActiveForm { get; set; }
		public SettingsModel Settings { get; set; }

		private FormsContext()
		{
			var provider = new XmlDataProvider<SettingsModel>("settings.xml", null);
			Settings = provider.Load() ?? new SettingsModel();
		}
	}
}
