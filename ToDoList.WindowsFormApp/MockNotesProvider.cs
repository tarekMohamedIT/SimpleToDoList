using System;
using System.Collections.Generic;
using ToDoList.Core.Models;
using ToDoList.Core.Persistence.DataProviders;

namespace ToDoList.WindowsFormApp
{
	public class MockNotesProvider : IDataProvider<Note>
	{
		public IEnumerable<Note> Query => _table;
		public IEnumerable<Note> ReadOnlyQuery => _table;

		private List<Note> _table;

		public MockNotesProvider()
		{

			_table = new List<Note>(){
					new Note() { Id = 1, CreationDate = DateTime.Now, Name = "Test1"},
					new Note() { Id = 2, CreationDate = DateTime.Now, Name = "Test2"},
					new Note() { Id = 3, CreationDate = DateTime.Now, Name = "Test3"},
					new Note() { Id = 4, CreationDate = DateTime.Now, Name = "Test4"}
			};
		}

		public void Save()
		{
		}

		public void Dispose()
		{
		}
	}
}
