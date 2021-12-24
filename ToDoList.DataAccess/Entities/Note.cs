using System;
using System.Globalization;
using System.Xml;

namespace ToDoList.DataAccess.Entities
{
	public class Note : BaseNote
	{
		/// <summary>
		/// The body of the simple note
		/// </summary>
		public string Text { get; set; }
	}
}
