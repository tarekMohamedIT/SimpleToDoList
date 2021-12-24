using System.Collections.Generic;

namespace ToDoList.DataAccess.Entities
{
	public class SectionedCheckList : BaseNote
	{
		public List<CheckListSection> Sections { get; set; }
	}
}