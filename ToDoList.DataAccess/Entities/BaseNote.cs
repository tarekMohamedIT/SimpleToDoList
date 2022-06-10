using System;

namespace ToDoList.DataAccess.Entities
{
	/// <summary>
	/// This class is a base for ever note there is
	/// </summary>
	/// <remarks>
	/// Contains the common properties that are shared across all note types
	/// </remarks>
	[Serializable]
	public abstract class BaseNote : IAuditedEntity
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public DateTime CreationDate { get; set; }
		public DateTime LastModificationDate { get; set; }
	}
}