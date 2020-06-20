using System;
using System.Collections.Generic;
using ToDoList.Core.Models;
using ToDoList.Core.Persistence.DataProviders;

namespace ToDoList.WindowsFormApp
{
	public class MockNotesProvider : IDataProvider<BaseNote>
	{
		public IEnumerable<BaseNote> Query => _table;
		public IEnumerable<BaseNote> ReadOnlyQuery => _table;

		private List<BaseNote> _table;

		public MockNotesProvider()
		{

			_table = new List<BaseNote>(){
				new Note()
				{
					Id = 0,
					Title = "A simple note",
					Text = "Just a simple note",
					CreationDate = DateTime.Now
				},

				new Note()
				{
				Id = 1,
				Title = "A simple note",
				Text = "Just a simple note",
				CreationDate = DateTime.Now
			},

			new CheckList()
			{
				Id = 2,
				Title = "A simple note",
				Items = new List<ChecklistItem>()
				{
					new ChecklistItem(){Text = "Wake up", Checked = false},
					new ChecklistItem(){Text = "Breakfast", Checked = false},
					new ChecklistItem(){Text = "Workout", Checked = false},
					new ChecklistItem(){Text = "Go to work", Checked = false}
				}
			}};
		}

		public void Save()
		{
		}

		public void Dispose()
		{
		}
	}
}
