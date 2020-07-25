using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ToDoList.Core.Models;

namespace ToDoList.WindowsFormApp.Models.ViewModels
{
	public class SectionedCheckListViewModel : BaseNoteViewModel<SectionedCheckList>
	{
		private SectionedCheckList _entity;
		private FlowLayoutPanel _checkListControl;
		private FlowLayoutPanel _toolsControl;
		private FlowLayoutPanel _currentSelectedSectionControl;
		private FlowLayoutPanel _currentSelectedItemControl;
		private Label _textboxLabel;
		private TextBox _textbox;
		private bool editSectionText;
		public override SectionedCheckList Entity
		{
			get
			{
				_entity.Title = titleBox.Text;
				_entity.Sections.Clear();
				CheckListSection currentSection = null;
				foreach (Control checkListControl in _checkListControl.Controls)
				{
					foreach (var sectionControl in checkListControl.Controls)
					{
						if (sectionControl is Label label)
						{
							currentSection = new CheckListSection()
							{
								Title = label.Text
							};
							_entity.Sections.Add(currentSection);
						}

						else if (sectionControl is FlowLayoutPanel checkLayoutPanel)
						{
							currentSection.Items.Add(new ChecklistItem()
							{
								Text = checkLayoutPanel.Controls[1].Text,
								Checked = (checkLayoutPanel.Controls[0] as CheckBox)?.Checked ?? false
							});
						}
					}
				}

				return _entity;
			}
			set => _entity = value;
		}

		public SectionedCheckListViewModel()
		{
			_checkListControl = new FlowLayoutPanel()
			{
				AutoScroll = true,
				BorderStyle = BorderStyle.FixedSingle,
				Dock = DockStyle.Fill,
				FlowDirection = FlowDirection.TopDown,
				WrapContents = false,
				Height = 250
			};

			_toolsControl = new FlowLayoutPanel()
			{
				Padding = new Padding(0),
				BorderStyle = BorderStyle.FixedSingle,
				Dock = DockStyle.Bottom,
				FlowDirection = FlowDirection.LeftToRight,
				WrapContents = false,
				Height = 100,
				AutoSize = true
			};

			_currentSelectedSectionControl = null;
		}

		public override void InitControl(Control container)
		{

			container.Controls.Clear();
			base.InitControl(container);
			container.Controls.Add(_checkListControl);
			container.Controls.Add(_toolsControl);

			titleBox.Text = _entity.Title;

			foreach (var section in _entity.Sections)
			{
				_checkListControl.Controls.Add(InitNewSection(section.Title, section.Items));
			}

			InitTextBoxControl(_toolsControl);
			InitCheckListButtons(_toolsControl);
		}

		private void InitCheckListButtons(Control container)
		{
			InitButton(container, "Add section", (sender, args) =>
			{
				var section = InitNewSection("new section", null);
				_checkListControl.Controls.Add(section);
				SelectSection(section);
				section.Focus();
			});

			InitButton(container, "Add item", (sender, args) =>
			{
				if (_currentSelectedSectionControl == null) return;

				var section = CreateSectionItem(new ChecklistItem(){Text = "new section"}, _currentSelectedSectionControl);


				_currentSelectedSectionControl.Controls.Add(section);
				section.Focus();
			});

			InitButton(container, "Remove", (sender, args) =>
			{
				if (editSectionText && _currentSelectedSectionControl != null)
				{
					_checkListControl.Controls.Remove(_currentSelectedSectionControl);
					_currentSelectedSectionControl = null;
				}

				else if (!editSectionText && _currentSelectedItemControl != null)
				{
					_currentSelectedSectionControl.Controls.Remove(_currentSelectedItemControl);
					_currentSelectedItemControl = null;
				}
			});
		}

		private void InitTextBoxControl(Control container)
		{
			var textControl = new FlowLayoutPanel()
			{
				FlowDirection = FlowDirection.TopDown,
				WrapContents = false,
				Width = 251
			};

			_textbox = new TextBox()
			{
				Width = 250
			};
			_textboxLabel  = new Label()
			{
				Text = "Title",
				Dock = DockStyle.Top,
				AutoSize = true,
				TextAlign = ContentAlignment.MiddleCenter
			};

			textControl.Controls.Add(_textboxLabel);
			textControl.Controls.Add(_textbox);

			InitButton(textControl, "Save", (sender, args) =>
			{
				if (editSectionText)
					_currentSelectedSectionControl.Controls[0].Text = _textbox.Text;
				else
					_currentSelectedItemControl.Controls[1].Text = _textbox.Text;
			});

			container.Controls.Add(textControl);
		}

		private FlowLayoutPanel InitNewSection(string text, List<ChecklistItem> items)
		{
			var sectionLayout = new FlowLayoutPanel()
			{
				FlowDirection = FlowDirection.TopDown,
				WrapContents = false,
				AutoSize = true
			};

			var header = CreateSectionHeader(text, sectionLayout);

			sectionLayout.Controls.Add(header);

			if (items == null || items.Count == 0) return sectionLayout;
			foreach (var item in items)
			{
				sectionLayout.Controls.Add(CreateSectionItem(item, sectionLayout));
			}

			return sectionLayout;
		}

		private FlowLayoutPanel CreateSectionItem(ChecklistItem item, Control parent)
		{
			var checkboxFlowLayout = new FlowLayoutPanel()
			{
				FlowDirection = FlowDirection.LeftToRight,
				WrapContents = false,
				AutoSize = true,
				Parent = parent
			};
			
			var checkboxControl = new CheckBox()
			{
				Text = "",
				Checked = item.Checked,
				AutoSize = true,
				Dock = DockStyle.Left,
				Anchor = AnchorStyles.Top | AnchorStyles.Left
			};

			var checkboxLabel = new Label()
			{
				Text = item.Text,
				AutoSize = true,
				Dock = DockStyle.Left,
				TextAlign = ContentAlignment.MiddleCenter,
				Anchor = AnchorStyles.Top | AnchorStyles.Left
			};

			checkboxLabel.Click += (sender, args) =>
			{
				_currentSelectedItemControl = checkboxFlowLayout;
				_textbox.Text = checkboxLabel.Text;
				editSectionText = false;
				SelectSection(parent as FlowLayoutPanel);
			};

			checkboxFlowLayout.Controls.Add(checkboxControl);
			checkboxFlowLayout.Controls.Add(checkboxLabel);

			return checkboxFlowLayout;
		}

		private Label CreateSectionHeader(string text, FlowLayoutPanel sectionLayout)
		{
			var header = new Label() {Text = text, AutoSize = true, Dock = DockStyle.Top, Parent = sectionLayout};
			header.Click += (sender, args) =>
			{
				SelectSection(header.Parent as FlowLayoutPanel);

				_textbox.Text = header.Text;
				editSectionText = true;
			};
			return header;
		}

		private void SelectSection(FlowLayoutPanel section)
		{
			if (_currentSelectedSectionControl != null)
				_currentSelectedSectionControl.BorderStyle = BorderStyle.None;

			_currentSelectedSectionControl = section;

			if (_currentSelectedSectionControl != null)
				_currentSelectedSectionControl.BorderStyle = BorderStyle.FixedSingle;
		}

		private void InitButton(Control container, string title, EventHandler clickHandler)
		{
			var button = new Button()
			{
				Text = title,
			};

			if (clickHandler != null)
				button.Click += clickHandler;

			container.Controls.Add(button);
		}

		private void SwapSelectedItemInCheckList(CheckedListBox checkList, int to)
		{
			if (to == checkList.Items.Count || to < 0) return;
			var selectedItem = checkList.SelectedItem;

			checkList.Items.Remove(selectedItem);
			checkList.Items.Insert(to, selectedItem);
			checkList.SelectedIndex = to;
		}
	}

	public class MockedSectionedCheckListViewModel : SectionedCheckListViewModel
	{
		public MockedSectionedCheckListViewModel()
		{
			Entity = new SectionedCheckList()
			{
				Id = 15,
				CreationDate = DateTime.Now,
				Title = "Mocked up",
				Sections = new List<CheckListSection>()
				{
					new CheckListSection()
					{
						Title = "Intro", Items = new List<ChecklistItem>()
						{
							new ChecklistItem(){Text = "Wakeup", Checked = false},
							new ChecklistItem(){Text = "Have breakfast", Checked = false},
							new ChecklistItem(){Text = "Get dressed", Checked = false},
						}
					},
					new CheckListSection()
					{
						Title = "At work", Items = new List<ChecklistItem>()
						{
							new ChecklistItem(){Text = "Start working", Checked = false},
							new ChecklistItem(){Text = "Program a new feature", Checked = false},
							new ChecklistItem(){Text = "Feel good", Checked = false},
						}
					},

					new CheckListSection()
					{
						Title = "At home", Items = new List<ChecklistItem>()
						{
							new ChecklistItem(){Text = "Chill", Checked = false},
							new ChecklistItem(){Text = "Be proud of yourself", Checked = false},
						}
					},
				}
			};
		}
	}
}