using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ToDoList.Core;
using ToDoList.Core.Services;
using ToDoList.CoreTests.Logging;
using ToDoList.DataAccess.DataProviders;
using ToDoList.DataAccess.Entities;
using ToDoList.Utils.Logging;

namespace ToDoList.CoreTests
{
	[TestClass]
	public class BasicNoteTest
	{
		private BaseCrudService<BaseNote> _notesService;

		[TestInitialize]
		public void Init()
		{
			var appServices = AppServicesResolver.Current;
			appServices.Register<ILogger>(() => new ConsoleLogger());

			appServices.Register<IDataProvider<List<BaseNote>>>(
				() => new MemoryDataProvider<List<BaseNote>>(new List<BaseNote>()));

			appServices.Register<BaseCrudService<BaseNote>>(
				() =>  BaseCrudService<BaseNote>.Create(appServices.Resolve<IDataProvider<List<BaseNote>>>()));

			_notesService = appServices.Resolve<BaseCrudService<BaseNote>>();
		}

		[TestMethod]
		public void Notes_AreInserted_Success()
		{
			AssertIsInserted(new Note()
			{
				Id = 0,
				Title = "A simple note",
				Text = "Just a simple note",
				CreationDate = DateTime.Now
			});

			AssertIsInserted(new Note()
			{
				Id = 1,
				Title = "A simple note",
				Text = "Just a simple note",
				CreationDate = DateTime.Now
			});

			AssertIsInserted(new CheckList()
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
		}

		private void AssertIsInserted(BaseNote note)
		{
			var result = _notesService.Insert(note);

			Assert.IsTrue(result.State == Utils.Results.ResultState.Success, result.Exception?.Message ?? "Success");
		}
	}
}
