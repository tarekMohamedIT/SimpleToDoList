using System.Windows.Forms;
using ToDoList.DataAccess.DataProviders;
using ToDoList.WindowsFormApp.Adapters;
using ToDoList.WindowsFormApp.Builders;
using ToDoList.WindowsFormApp.Contexts;
using ToDoList.WindowsFormApp.Factories;
using ToDoList.WindowsFormApp.Models.ViewModels;

namespace ToDoList.WindowsFormApp.Forms.ThemesForms
{
	public partial class ThemesIndexForm : Form
	{
		private TableLayoutAdapter<Control> _adapter;
		private IDataProvider<ThemesViewModel> _dataProvider;
		private ThemesViewModel _themes;

		public ThemesIndexForm()
		{
			InitializeComponent();

			_dataProvider = ThemeFactory.ThemesProvider;
			_themes = _dataProvider.Load() ?? new ThemesViewModel();

			if (_themes.ThemesList.Count == 0)
			{
				_themes.ThemesList.Add(ThemeFactory.Default);
			}

			InitTable();
		}

		private void InitTable()
		{
			_adapter = new TableLayoutAdapter<Control>(tableLayoutPanel1, false);

			foreach (var theme in _themes.ThemesList)
			{
				var label = new Label()
				{
					Text = theme.Title,
					BackColor = theme.MainPanelBackgroundColor,
					ForeColor = theme.SidePanelMainTextColor,
					Margin = new Padding(3, 3, 3, 3),
					Dock = DockStyle.Fill,
					Height = 45
				};

				label.Click += (sender, args) =>
				{
					_dataProvider.Item.SelectedTheme = label.Text;
					_dataProvider.Save();

					FormsContext.Instance.CurrentTheme = ThemeFactory.GetCurrent();
					SideMenuBuilder.GetInstance().ChangeTheme(FormsContext.Instance.CurrentTheme);

					FormsContext.Instance.CurrentActiveForm?.Close();
				};

				_adapter.Add(label);
			}

		}
	}
}
