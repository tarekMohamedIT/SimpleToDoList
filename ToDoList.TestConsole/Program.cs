using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.Models;
using ToDoList.Core.Persistence.DataProviders;
using ToDoList.Core.Persistence.Repositories.Concrete;

namespace ToDoList.TestConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			var xmlProvider = new XmlDataProvider<BaseNote>("notes.xml", new[]
			{
				typeof(Note),
				typeof(CheckList)
			});

			var repo = new BaseMemoryRepository<BaseNote>(xmlProvider);

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

			xmlProvider.Save();

			Console.Write("Text completed");
			Console.Read();
		}
	}
}
