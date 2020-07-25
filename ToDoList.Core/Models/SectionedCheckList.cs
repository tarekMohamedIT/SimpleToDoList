using System.Collections.Generic;

namespace ToDoList.Core.Models
{
	public class SectionedCheckList : BaseNote
	{
		public List<CheckListSection> Sections { get; set; }
	}
}