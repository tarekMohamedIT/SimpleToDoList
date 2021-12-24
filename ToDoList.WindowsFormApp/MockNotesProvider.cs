using System;
using System.Collections.Generic;
using ToDoList.DataAccess.DataProviders;
using ToDoList.DataAccess.Entities;

namespace ToDoList.WindowsFormApp
{
	public class MockNotesProvider : IDataProvider<List<BaseNote>>
	{

		public List<BaseNote> Item { get; set; }

		public MockNotesProvider()
		{

			Item = Load();
		}

		public void Save()
		{
		}

		public List<BaseNote> Load()
		{
			return new List<BaseNote>(){
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

		public void Dispose()
		{
		}
	}
}
