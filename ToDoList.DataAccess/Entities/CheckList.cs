using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ToDoList.DataAccess.Entities
{
	public class CheckList : BaseNote
	{
		/// <summary>
		/// The items list of this checklist
		/// </summary>
		public List<ChecklistItem> Items { get; set; }
	}
}