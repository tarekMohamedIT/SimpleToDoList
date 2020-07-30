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
using ToDoList.WindowsFormApp.Builders;
using ToDoList.WindowsFormApp.Contexts;
using ToDoList.WindowsFormApp.Factories;
using ToDoList.WindowsFormApp.Models;
using ToDoList.WindowsFormApp.Models.ViewModels;

namespace ToDoList.WindowsFormApp.Forms.ThemesForms
{
	public partial class CreateThemeForm : Form
	{
		public static ThemeModel Instance { get; set; }
		public static ThemeModel EditInstance { get; set; }
		private bool _previewed;
		private bool _isEdit;
		private IDataProvider<ThemesViewModel> _dataProvider;

		public CreateThemeForm(bool isEdit)
		{
			_isEdit = isEdit;
			InitializeComponent();

			if (isEdit && ThemeFactory.GetCurrent().Title.Trim().ToLower() == "default")
			{
				MessageBox.Show("You can't edit the default template");
				return;
			}

			if (isEdit)
			{
				EditInstance = ThemeFactory.GetCurrent();
				textBox1.Enabled = false;
			}

			InitializeTextBoxes();

		}

		private void InitializeTextBoxes()
		{
			var instance = _isEdit ? EditInstance : Instance;

			if (instance != null)
			{
				textBox1.Text = instance.Title;
				textBox2.Text = instance.SidePanelMainColorStr;
				textBox3.Text = instance.SidePanelMainTextColorStr;
				textBox4.Text = instance.SidePanelSubMenuColorStr;
				textBox5.Text = instance.SidePanelSubMenuTextColorStr;
				textBox6.Text = instance.MainPanelBackgroundColorStr;
			}
			
		}

		private void button1_Click(object sender, EventArgs e)
		{
			_previewed = true;
			var instance = new ThemeModel()
			{
				Title = textBox1.Text,
				SidePanelMainColorStr = textBox2.Text,
				SidePanelMainTextColorStr = textBox3.Text,
				SidePanelSubMenuColorStr = textBox4.Text,
				SidePanelSubMenuTextColorStr = textBox5.Text,
				MainPanelBackgroundColorStr = textBox6.Text
			};

			if (_isEdit)
				EditInstance = instance;
			else
				Instance = instance;

			SideMenuBuilder.GetInstance().ChangeTheme(instance);
		}

		private void CreateThemeForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!_previewed)
			{
				Instance = null;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{

			_dataProvider = ThemeFactory.ThemesProvider;

			if (!_isEdit)
			{
				if (Instance.Title.Trim().ToLower() == "default")
					MessageBox.Show("You can't add a theme with a title of default");

				Instance = new ThemeModel()
				{
					Title = textBox1.Text,
					SidePanelMainColorStr = textBox2.Text,
					SidePanelMainTextColorStr = textBox3.Text,
					SidePanelSubMenuColorStr = textBox4.Text,
					SidePanelSubMenuTextColorStr = textBox5.Text,
					MainPanelBackgroundColorStr = textBox6.Text
				};

				if (_dataProvider.Item == null)
					_dataProvider.Item = ThemeFactory.NewInstance();

				_dataProvider.Item.ThemesList.Add(Instance);
			}

			else
			{

				var saved = _dataProvider.Item.ThemesList.FirstOrDefault(t => t.Title == EditInstance.Title);

				saved.SidePanelMainColorStr = textBox2.Text;
				saved.SidePanelMainTextColorStr = textBox3.Text;
				saved.SidePanelSubMenuColorStr = textBox4.Text;
				saved.SidePanelSubMenuTextColorStr = textBox5.Text;
				saved.MainPanelBackgroundColorStr = textBox6.Text;
			}

			_dataProvider.Save();

			Instance = null;
			EditInstance = null;

			FormsContext.Instance.CurrentTheme = ThemeFactory.GetCurrent();
			SideMenuBuilder.GetInstance().ChangeTheme(FormsContext.Instance.CurrentTheme);
			this.Close();
		}
	}
}
