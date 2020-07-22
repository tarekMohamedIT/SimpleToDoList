using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoList.Core.Persistence.DataProviders;
using ToDoList.WindowsFormApp.Contexts;
using ToDoList.WindowsFormApp.Models;

namespace ToDoList.WindowsFormApp.Forms
{
	public partial class SettingsForm : Form
	{
		public SettingsForm()
		{
			InitializeComponent();
			InitializeSettings();
		}

		private void SettingsForm_Load(object sender, EventArgs e)
		{

		}

		private void InitializeSettings()
		{
			useTitleCheckBox.Checked = FormsContext.Instance.Settings.UseTitleForNotesList;
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			var provider = new XmlDataProvider<SettingsModel>("settings.xml", null);
			provider.Item = FormsContext.Instance.Settings;

			provider.Save();
		}

		private void useTitleCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			FormsContext.Instance.Settings.UseTitleForNotesList = useTitleCheckBox.Checked;
		}
	}
}
