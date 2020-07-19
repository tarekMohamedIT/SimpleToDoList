using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.WindowsFormApp.Models.SubMenuModels
{
	public class SubMenuModel
	{
		public string Name { get; set; }
		public virtual EventHandler OnClick { get; set; }
		public virtual List<SubMenuModel> SubMenuItems { get; set; }
	}
}
