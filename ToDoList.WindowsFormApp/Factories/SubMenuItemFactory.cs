using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoList.WindowsFormApp.Models.SubMenuModels;

namespace ToDoList.WindowsFormApp.Factories
{
	public class SubMenuItemFactory
	{
		public static SubMenuItemFactory Instance => new SubMenuItemFactory();

		public SubMenuModel CreateMainMenuModel(string name, List<SubMenuModel> subItems)
		{
			return new SubMenuModel()
			{
				Name = name,
				SubMenuItems = subItems
			};
		}

		public SubMenuModel CreateOpenFormMenuModel(string name, Func<Form> formFactory, Panel parent)
		{
			return new OpenFormSubMenuModel(formFactory, parent)
			{
				Name = name
			};
		}
	}
}
