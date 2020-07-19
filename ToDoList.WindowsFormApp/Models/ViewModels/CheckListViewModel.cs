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

			var saveNoteButton = new Button()
			{
				Text = "Save note",
			};

			var addNewButton = new Button()
			{
				Text = "Add new"
			};

			var removeSelectedButton = new Button()
			{
				Text = "Remove selected"
			};

			var moveUpButton = new Button()
			{
				Text = "Move Up"
			};

			var moveDownButton = new Button()
			{
				Text = "Move Down"
			};

			_checkListControl.SelectedIndexChanged += (sender, args) =>
			{
				if (_checkListControl.SelectedItem != null)
					checkTextBox.Text = _checkListControl.SelectedItem.ToString();
			};

			addNewButton.Click += (sender, args) =>
			{
				_checkListControl.Items.Add("New Item", CheckState.Unchecked);
				_checkListControl.SelectedIndex = _checkListControl.Items.Count - 1;
			};

			saveNoteButton.Click += (sender, args) =>
			{
				_checkListControl.Items[_checkListControl.SelectedIndex] = checkTextBox.Text;
				checkTextBox.Text = "";
			};

			removeSelectedButton.Click += (sender, args) =>
			{
				_checkListControl.Items.RemoveAt(_checkListControl.SelectedIndex);
				checkTextBox.Text = "";
			};

			moveUpButton.Click += (sender, args) =>
			{
				var selectedIndex = _checkListControl.SelectedIndex;

				if (selectedIndex == 0) return;
				var selectedItem = _checkListControl.SelectedItem;

				_checkListControl.Items.Remove(selectedItem);
				_checkListControl.Items.Insert(selectedIndex - 1, selectedItem);
				_checkListControl.SelectedIndex = selectedIndex - 1;
			};

			moveDownButton.Click += (sender, args) =>
			{
				var selectedIndex = _checkListControl.SelectedIndex;

				if (selectedIndex == _checkListControl.Items.Count - 1) return;
				var selectedItem = _checkListControl.SelectedItem;

				_checkListControl.Items.Remove(selectedItem);
				_checkListControl.Items.Insert(selectedIndex + 1, selectedItem);
				_checkListControl.SelectedIndex = selectedIndex + 1;
			};

			container.Controls.Add(checkTextBox);
			container.Controls.Add(saveNoteButton);
			container.Controls.Add(addNewButton);
			container.Controls.Add(moveUpButton);
			container.Controls.Add(moveDownButton);
			container.Controls.Add(removeSelectedButton);
		}
	}
}
