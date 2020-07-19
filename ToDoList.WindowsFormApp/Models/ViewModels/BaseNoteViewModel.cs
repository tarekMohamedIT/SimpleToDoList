using System.Windows.Forms;

namespace ToDoList.WindowsFormApp.Models.ViewModels
{
	public abstract class BaseNoteViewModel<TEntity> : INoteViewModel<TEntity>
	{
		public virtual TEntity Entity { get; set; }
		protected TextBox titleBox;

		object INoteViewModel.Entity => Entity;

		public virtual void InitControl(Control container)
		{
			var label = new Label()
			{
				Text = "Title"
			};
			titleBox = new TextBox {Width = 610};

			container.Controls.Add(label);
			container.Controls.Add(titleBox);
		}
	}
}