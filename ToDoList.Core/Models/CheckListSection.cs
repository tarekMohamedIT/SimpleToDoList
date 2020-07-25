using System.Collections.Generic;

namespace ToDoList.Core.Models
{
	public class CheckListSection
	{
		public string Title { get; set; }
		public List<ChecklistItem> Items { get; set; }
	}
}