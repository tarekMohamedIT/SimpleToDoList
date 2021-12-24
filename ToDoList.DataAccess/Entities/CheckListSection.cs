using System.Collections.Generic;

namespace ToDoList.DataAccess.Entities
{
	public class CheckListSection
	{
		public CheckListSection()
		{
			Items = new List<ChecklistItem>();
		}

		public string Title { get; set; }
		public List<ChecklistItem> Items { get; set; }
	}
}