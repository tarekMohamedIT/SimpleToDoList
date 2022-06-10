using System;

namespace ToDoList.DataAccess.Filters
{
	public class BaseNoteFilter
	{
		public int? Id { get; set; }

		public string Title { get; set; }

		public DateTime? CreationDate { get; set; }
	}
}
