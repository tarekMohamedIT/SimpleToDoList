﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ToDoList.WindowsFormApp.Contexts;
using ToDoList.WindowsFormApp.Factories;
using ToDoList.WindowsFormApp.Models;
using ToDoList.WindowsFormApp.Models.SubMenuModels;

namespace ToDoList.WindowsFormApp.Builders
{
	public class SideMenuBuilder
	{
		private static SideMenuBuilder _instance;

		public static SideMenuBuilder GetInstance(ThemeModel theme = null)
		{
			if (_instance != null) return _instance;
			_instance = new SideMenuBuilder {Theme = theme};

			return _instance;
		}

		private Panel _sideMenu;
		private Panel _mainPanel;

		public ThemeModel Theme { get; private set; }
		public List<SubMenuModel> MenuModels { get; set; }

		public void Rebuild()
		{
			Build(_sideMenu, _mainPanel);
		}

		public void Build(Panel sideMenu, Panel mainPanel)
		{
			_mainPanel = mainPanel;
			_sideMenu = sideMenu;

			ApplyThemeColors(_sideMenu, _mainPanel);

			var controls = new List<Control>();
			sideMenu.Controls.Clear();

			if (MenuModels == null || MenuModels.Count == 0) return;

			foreach (var menu in MenuModels)
			{
				var mainBtn = BuildMainMenuItem(menu.Name);

				if (menu.SubMenuItems == null || menu.SubMenuItems.Count == 0) // A main button
				{
					mainBtn.Click += menu.OnClick;
					controls.Add(mainBtn);
				}

				else // A main item with a list of sub items
				{
					var subPanel = BuildSubMenuPanel(menu.SubMenuItems);
					mainBtn.Click += (sender, args) => { subPanel.Visible = !subPanel.Visible; };

					controls.Add(mainBtn);
					controls.Add(subPanel);
				}
			}

			controls.Reverse();
			sideMenu.Controls.AddRange(controls.ToArray());

			sideMenu.Controls.Add(BuildLogoPanel());
		}

		private void ApplyThemeColors(Panel sideMenuPanel, Panel mainPanel)
		{
			Theme = FormsContext.Instance.CurrentTheme;
			sideMenuPanel.BackColor = Theme.SidePanelMainColor;
			mainPanel.BackColor = Theme.MainPanelBackgroundColor;
		}

		private Button BuildMainMenuItem(string name)
		{
			var button = new Button()
			{
				Text = name,
				Dock = DockStyle.Top,
				Height = 45,
				BackColor = Theme.SidePanelMainColor,
				FlatStyle = FlatStyle.Flat,
				FlatAppearance = { BorderSize = 0 },
				ForeColor = Theme.SidePanelMainTextColor,
				TextAlign = ContentAlignment.MiddleLeft,
				Padding = new Padding(10, 0, 0, 0)
			};

			return button;
		}

		private Panel BuildSubMenuPanel(List<SubMenuModel> submenuItems)
		{
			var panel = new Panel()
			{
				Height = (submenuItems.Count * 45) + submenuItems.Count,
				BackColor = Theme.SidePanelSubMenuColor,
				Dock = DockStyle.Top,
				Visible = false,
				AutoScroll = true
			};

			var subControls = new List<Control>();
			foreach (var subMenuItem in submenuItems)
			{
				subControls.Add(BuildSubMenuItem(subMenuItem));
			}

			subControls.Reverse();
			panel.Controls.AddRange(subControls.ToArray());

			return panel;
		}

		private Button BuildSubMenuItem(SubMenuModel metaData)
		{
			var button = new Button()
			{
				Text = metaData.Name,
				Dock = DockStyle.Top,
				Height = 45,
				BackColor = Theme.SidePanelSubMenuColor,
				FlatStyle = FlatStyle.Flat,
				FlatAppearance = { BorderSize = 0 },
				ForeColor = Theme.SidePanelSubMenuTextColor,
				TextAlign = ContentAlignment.MiddleLeft,
				Padding = new Padding(35, 0, 0, 0)
			};

			button.Click += metaData.OnClick;
			return button;
		}

		private Panel BuildLogoPanel()
		{
			var panel = new Panel()
			{
				BackColor = Theme.SidePanelMainColor,
				Height = 100,
				Dock = DockStyle.Top
			};

			var label = new Label()
			{
				Text = "My notepad",
				ForeColor = Theme.SidePanelMainTextColor,
				Font = new Font("Modern No. 20", 22),
				TextAlign = ContentAlignment.MiddleCenter,
				Dock = DockStyle.Fill
			};

			label.Click += (sender, args) => FormsContext.Instance.CurrentActiveForm?.Close();

			panel.Controls.Add(label);

			return panel;
		}

		public void ChangeTheme(ThemeModel theme)
		{
			Theme = theme;
			Build(_sideMenu, _mainPanel);
		}
		
	}
}
