using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ToDoList.DataAccess.Entities
{
	/// <summary>
	/// This class is a base for ever note there is
	/// </summary>
	/// <remarks>
	/// Contains the common properties that are shared across all note types
	/// </remarks>
	[Serializable]
	public abstract class BaseNote : IEntity
	{
		/// <value>
		/// The Id from IEntity interface.
		/// </value>
		///
		/// <summary>
		/// The Id from IEntity interface.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// The title of the Note
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// The date and time on which the note is created
		/// </summary>
		public DateTime CreationDate { get; set; }
	}
}