using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.Models;
using ToDoList.Core.Persistence.DataProviders;
using ToDoList.Core.Persistence.Repositories.Concrete;

namespace SimpleToDoList
{
	class Program
	{
		static void Main(string[] args)
		{
			// The code provided will print ‘Hello World’ to the console.
			// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
			Console.WriteLine("Hello World!");

			var repo = new BaseMemoryRepository<Note>(new JsonDataProvider<Note>("JsonTest.json"));

			repo.Insert(
				new List<Note>(){
					new Note() { Id = 1, CreationDate = DateTime.Now, Name = "Test1"},
					new Note() { Id = 2, CreationDate = DateTime.Now, Name = "Test2"},
					new Note() { Id = 3, CreationDate = DateTime.Now, Name = "Test3"},
					new Note() { Id = 4, CreationDate = DateTime.Now, Name = "Test4"}
				});

			//repo.Save();

			Console.WriteLine("Repo saved the xml successfully!");
			Console.ReadKey();

			// Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
		}
	}
}
