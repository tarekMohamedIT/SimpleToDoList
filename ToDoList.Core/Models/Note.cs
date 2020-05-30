using System;

namespace ToDoList.Core.Models
{
	public class Note : IEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Text { get; set; }
		public DateTime CreationDate { get; set; }
	}
}
