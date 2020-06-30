using System;
using System.Collections.Generic;
using ToDoList.Core.Models;
using ToDoList.Core.Persistence.DataProviders;
using ToDoList.Core.Persistence.Repositories.Concrete;

namespace ToDoList.TestConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			IDataProvider<BaseNote> dataProvider;

			//dataProvider = new XmlDataProvider<BaseNote>("notesConsole.xml", new[]
			//{
			//	typeof(Note),
			//	typeof(CheckList)
			//}, new ConsoleLogger());

			dataProvider = new JsonDataProvider<BaseNote>("notesConsole.json", new ConsoleLogger());

			var repo = new BaseMemoryRepository<BaseNote>(dataProvider);

			repo.Insert(new Note()
			{
				Id = 0,
				Title = "A simple note",
				Text = "Just a simple note",
				CreationDate = DateTime.Now
			});

			repo.Insert(new Note()
			{
				Id = 1,
				Title = "A simple note",
				Text = "Just a simple note",
				CreationDate = DateTime.Now
			});

			repo.Insert(new CheckList()
			{
				Id = 0,
				Title = "A simple note",
				Items = new List<ChecklistItem>()
				{
					new ChecklistItem(){Text = "Wake up", Checked = false},
					new ChecklistItem(){Text = "Breakfast", Checked = false},
					new ChecklistItem(){Text = "Workout", Checked = false},
					new ChecklistItem(){Text = "Go to work", Checked = false}
				}
			});

			dataProvider.Save();

			Console.Write("Text completed");
			Console.Read();
		}
	}
}
