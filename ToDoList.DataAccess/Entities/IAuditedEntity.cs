using System;

namespace ToDoList.DataAccess.Entities
{
	public interface IAuditedEntity : IEntity
	{
		DateTime CreationDate { get; set; }
		DateTime LastModificationDate { get; set; }
	}
}