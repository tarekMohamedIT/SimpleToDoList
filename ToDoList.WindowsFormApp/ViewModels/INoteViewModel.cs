using System.Windows.Forms;

namespace ToDoList.WindowsFormApp.ViewModels
{
	public interface INoteViewModel
	{
		object Entity { get; }
		void InitControl(Control container);
	}

	public interface INoteViewModel<out TEntity> : INoteViewModel
	{
		new TEntity Entity { get; }
	}
}