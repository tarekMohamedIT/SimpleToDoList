using System;
using System.Windows.Forms;
using ToDoList.Core.Models;

namespace ToDoList.WindowsFormApp.Models.ViewModels
{
	class CheckListViewModel : BaseNoteViewModel<CheckList>
	{
		private readonly CheckedListBox _checkListControl;
		private CheckList _entity;

		public override CheckList Entity
		{
			get
			{
				_entity.Title = titleBox.Text;
				_entity.Items.Clear();
				int count = 0;
				foreach (var checkListControl in _checkListControl.Items)
				{
					_entity.Items.Add(new ChecklistItem()
					{
						Text = checkListControl.ToString(),
						Checked = _checkListControl.GetItemCheckState(count++) == CheckState.Checked
					});
				}

				return _entity;
			}
			set => _entity = value;
		}

		public CheckListViewModel()
		{
			_checkListControl = new CheckedListBox()
			{
				Width = 610
			};
		}

		public override void InitControl(Control container)
		{

			container.Controls.Clear();
			base.InitControl(container);

			titleBox.Text = _entity.Title;

			foreach (var checklistItem in _entity.Items)
			{
				_checkListControl.Items.Add(checklistItem.Text, checklistItem.Checked);
			}

			container.Controls.Add(_checkListControl);
			var checkTextBox = new TextBox()
			{
				Width = 610
			};
			container.Controls.Add(checkTextBox);

			_checkListControl.SelectedIndexChanged += (sender, args) =>
			{
				if (_checkListControl.SelectedItem != null)
					checkTextBox.Text = _checkListControl.SelectedItem.ToString();
			};

			InitCheckListButtons(container, checkTextBox);
		}

		private void InitCheckListButtons(Control container, TextBox checkTextBox)
		{
			InitButton(container, "Save note", (sender, args) =>
			{
				_checkListControl.Items[_checkListControl.SelectedIndex] = checkTextBox.Text;
				checkTextBox.Text = "";
			});

			InitButton(container, "Add new", (sender, args) =>
			{
				_checkListControl.Items.Add("New Item", CheckState.Unchecked);
				_checkListControl.SelectedIndex = _checkListControl.Items.Count - 1;
			});

			InitButton(container, "Move Up", (sender, args) =>
			{
				var selectedIndex = _checkListControl.SelectedIndex;
				SwapSelectedItemInCheckList(_checkListControl, selectedIndex - 1);
			});

			InitButton(container, "Move Down", (sender, args) =>
			{
				var selectedIndex = _checkListControl.SelectedIndex;
				SwapSelectedItemInCheckList(_checkListControl, selectedIndex + 1);
			});

			InitButton(container, "Remove selected", (sender, args) =>
			{
				_checkListControl.Items.RemoveAt(_checkListControl.SelectedIndex);
				checkTextBox.Text = "";
			});
		}

		private void InitButton(Control container, string title, EventHandler clickHandler)
		{
			var button = new Button()
			{
				Text = title,
			};
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
}
