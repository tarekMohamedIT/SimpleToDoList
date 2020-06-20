using System.Drawing;
using System.Windows.Forms;
using ToDoList.Core.Models;

namespace ToDoList.WindowsFormApp.ViewModels
{
	public class SimpleNoteViewModel : BaseNoteViewModel<Note>
	{
		private readonly TextBox _noteTextBox;
		private Note _entity;

		public override Note Entity
		{
			get
			{
				_entity.Title = titleBox.Text;
				_entity.Text = _noteTextBox.Text;

				return _entity;
			}
			set => _entity = value;
		}


		public SimpleNoteViewModel()
		{
			_noteTextBox = new TextBox();
			_noteTextBox.Size = new Size(610, 189);
			_noteTextBox.Multiline = true;
		}

		public override void InitControl(Control container)
		{

			container.Controls.Clear();
			base.InitControl(container);

			titleBox.Text = _entity.Title;
			_noteTextBox.Text = _entity.Text;
			var label = new Label()
			{
				Text = "Title"
			};

			container.Controls.Add(label);
			container.Controls.Add(_noteTextBox);
		}
	}
}