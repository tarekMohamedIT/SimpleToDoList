using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.Persistence.DataProviders;
using ToDoList.WindowsFormApp.Models;
using ToDoList.WindowsFormApp.Models.ViewModels;

namespace ToDoList.WindowsFormApp.Factories
{
	public class ThemeFactory
	{
		public static ThemeModel Default { get; } = new ThemeModel()
		{
			Title = "Default",

			SidePanelMainColorStr = "11,7,17",
			SidePanelMainTextColorStr = "250 ,235 , 215",

			SidePanelSubMenuColorStr = "35, 32, 39",
			SidePanelSubMenuTextColorStr = "250 ,235 , 215",

			MainPanelBackgroundColorStr = "32, 30, 45",
		};

		public static ThemeModel GetCurrent()
		{
			var themeViewModel = ThemesProvider.Load();

			if (themeViewModel == null || string.IsNullOrWhiteSpace(themeViewModel.SelectedTheme))
				return Default;

			return themeViewModel.ThemesList.FirstOrDefault(t => t.Title == themeViewModel.SelectedTheme) ?? Default;
		}

		public static ThemesViewModel NewInstance()
		{
			return new ThemesViewModel()
			{
				SelectedTheme = "Default", 
				ThemesList = new List<ThemeModel>()
				{
					Default
				}
			};
		}

		public static IDataProvider<ThemesViewModel> ThemesProvider = new XmlDataProvider<ThemesViewModel>("themes.xml", null);
	}
}
