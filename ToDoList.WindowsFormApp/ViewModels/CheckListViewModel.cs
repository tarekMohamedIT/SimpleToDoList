using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoList.Core.Models;

namespace ToDoList.WindowsFormApp.ViewModels
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
			_checkListControl = new CheckedListBox();
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
			var checkTextBox = new TextBox();

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

			container.Controls.Add(checkTextBox);
			container.Controls.Add(saveNoteButton);
			container.Controls.Add(addNewButton);
			container.Controls.Add(removeSelectedButton);
		}
	}
}
