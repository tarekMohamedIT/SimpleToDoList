using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ToDoList.Core;
using ToDoList.Core.Services;
using ToDoList.CoreTests.Logging;
using ToDoList.DataAccess.DataProviders;
using ToDoList.DataAccess.Entities;
using ToDoList.DataAccess.Repositories;
using ToDoList.DataAccess.Repositories.Concrete;
using ToDoList.Utils.Logging;

namespace ToDoList.CoreTests
{
	[TestClass]
	public class BasicNoteTest : BaseTesting
	{
		private NotesService<BaseNote> _notesService;

		[TestInitialize]
		public void Init()
		{
			var appServices = AppServicesResolver.Current;
			appServices.Register<ILogger>(() => new ConsoleLogger());

			appServices.Register<IDataProvider<List<BaseNote>>>(
				() => new MemoryDataProvider<List<BaseNote>>(new List<BaseNote>()));

			appServices.Register("BaseNotesRepository",
				() => new NotesRepository<BaseNote>(appServices.Resolve<IDataProvider<List<BaseNote>>>()));

			_notesService = new NotesService<BaseNote>(appServices.Resolve<IGenericRepository<BaseNote>>());
		}

		[TestMethod]
		public void Notes_AreInserted_Success()
		{
			AssertInserted(new Note()
			{
				Id = 0,
				Title = "A simple note",
				Text = "Just a simple note",
				CreationDate = DateTime.Now
			});

			AssertInserted(new Note()
			{
				Id = 1,
				Title = "A simple note",
				Text = "Just a simple note",
				CreationDate = DateTime.Now
			});

			AssertInserted(new CheckList()
			{
				Id = 0,
				Title = "A simple note",
				Items = new List<ChecklistItem>()
				{
					new ChecklistItem(){Title = "Wake up", Checked = false},
					new ChecklistItem(){Title = "Breakfast", Checked = false},
					new ChecklistItem(){Title = "Workout", Checked = false},
					new ChecklistItem(){Title = "Go to work", Checked = false}
				}
			});
		}

		private void AssertInserted(BaseNote note)
		{
			var result = _notesService.Add(note);
			AssertTrue(result);
		}
	}
}
