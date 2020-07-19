using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.WindowsFormApp.Models.ViewModels
{
	public class ThemesViewModel
	{

		public string SelectedTheme { get; set; }

		public List<ThemeModel> ThemesList { get; set; }

		public ThemesViewModel()
		{
			ThemesList = new List<ThemeModel>();
		}
	}
}
