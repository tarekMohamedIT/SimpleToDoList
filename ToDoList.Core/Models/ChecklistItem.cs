namespace ToDoList.Core.Models
{
	public class ChecklistItem
	{
		/// <summary>
		/// The text of the item.
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// A bool to check whether this item is done or not.
		/// </summary>
		public bool Checked { get; set; }
	}
}