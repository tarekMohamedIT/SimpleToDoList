using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.WindowsFormApp.Models
{
	public class ThemeModel
	{
		public string Title { get; set; }
		public string SidePanelMainColorStr { get; set; }
		public string SidePanelMainTextColorStr { get; set; }
		public string SidePanelSubMenuColorStr { get; set; }
		public string SidePanelSubMenuTextColorStr { get; set; }
		public string MainPanelBackgroundColorStr { get; set; }

		public Color SidePanelMainColor => ColorTranslator.FromHtml(SidePanelMainColorStr);
		public Color SidePanelMainTextColor => ColorTranslator.FromHtml(SidePanelMainTextColorStr);
		public Color SidePanelSubMenuColor => ColorTranslator.FromHtml(SidePanelSubMenuColorStr);
		public Color SidePanelSubMenuTextColor => ColorTranslator.FromHtml(SidePanelSubMenuTextColorStr);
		public Color MainPanelBackgroundColor => ColorTranslator.FromHtml(MainPanelBackgroundColorStr);

	}
}
