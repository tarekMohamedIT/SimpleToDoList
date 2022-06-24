using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
	public class ChecklistsTests : BaseTesting
	{
		private ChecklistNoteService _notesService;
		private IGenericRepository<ChecklistItem> _checklistItems;
		private IGenericRepository<CheckList> _checklists;

		[TestInitialize]
		public void Init()
		{
			var appServices = AppServicesResolver.Current;
			appServices.Register<ILogger>(() => new ConsoleLogger());

			appServices.Register<IDataProvider<List<CheckList>>>(
				() => new MemoryDataProvider<List<CheckList>>(new List<CheckList>()));

			appServices.Register<IDataProvider<List<ChecklistItem>>>(
				() => new MemoryDataProvider<List<ChecklistItem>>(new List<ChecklistItem>()));

			appServices.Register<IGenericRepository<CheckList>>(
				() => new NotesRepository<CheckList>(appServices.Resolve<IDataProvider<List<CheckList>>>()));

			appServices.Register<IGenericRepository<ChecklistItem>>(
				() => new NotesRepository<ChecklistItem>(appServices.Resolve<IDataProvider<List<ChecklistItem>>>()));

			_checklists = appServices.Resolve<IGenericRepository<CheckList>>();
			_checklistItems = appServices.Resolve<IGenericRepository<ChecklistItem>>();

			_notesService = new ChecklistNoteService(
				_checklists,
				_checklistItems);
		}

		[TestMethod]
		public void Notes_AreInserted_Success()
		{

			var checklist = (new CheckList()
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

			AssertTrue(_notesService.Add(checklist));

			Assert.AreEqual(1, _checklists.GetAll(null).Count());
			Assert.AreEqual(4, _checklistItems.GetAll(null).Count());

		}
	}
}
