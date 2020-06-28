using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ToDoList.Core.Models
{
	public class CheckList : BaseNote
	{
		public List<ChecklistItem> Items { get; set; }
	}
}