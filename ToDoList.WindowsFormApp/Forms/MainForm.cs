using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ToDoList.WindowsFormApp.Builders;
using ToDoList.WindowsFormApp.Factories;
using ToDoList.WindowsFormApp.Forms.ThemesForms;
using ToDoList.WindowsFormApp.Models.SubMenuModels;

namespace ToDoList.WindowsFormApp.Forms
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

			InitializePanel(panel1);
		}

		private void InitializePanel(Panel panel)
		{
			var modelsFactory = SubMenuItemFactory.Instance;
			var builder = SideMenuBuilder.GetInstance();
			builder.MenuModels = new List<SubMenuModel>()
				{
					modelsFactory.CreateOpenFormMenuModel("My Notes", () => new Form1(), panelChildForm),
					modelsFactory.CreateMainMenuModel("Settings", new List<SubMenuModel>()
					{
						modelsFactory.CreateOpenFormMenuModel("General",
							() => new SettingsForm(), 
							panelChildForm),

						modelsFactory.CreateOpenFormMenuModel("Theme",
							() => new ThemesIndexForm(),
							panelChildForm),

						modelsFactory.CreateOpenFormMenuModel(
							"Create new",
							() => new CreateThemeForm(false),
							panelChildForm),

						modelsFactory.CreateOpenFormMenuModel(
							"Edit",
							() =>
							{
								if (ThemeFactory.GetCurrent().Title.Trim().ToLower() != "default")
									return new CreateThemeForm(true);
								MessageBox.Show("You cannot edit the default theme");
								return null;

							},
							panelChildForm),
					})
				};

			builder.Build(panel, panelChildForm);
		}

		private void MainForm_Load(object sender, EventArgs e)
		{

		}
	}
}
