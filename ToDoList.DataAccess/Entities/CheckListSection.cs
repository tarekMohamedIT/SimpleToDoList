using System.Collections.Generic;

namespace ToDoList.DataAccess.Entities
{
	public class CheckListSection : BaseNote
	{
		public CheckListSection()
		{
			Items = new List<ChecklistItem>();
		}
		
		public List<ChecklistItem> Items { get; set; }
	}
}