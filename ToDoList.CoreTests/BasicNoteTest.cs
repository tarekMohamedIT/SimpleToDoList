using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ToDoList.Core.Services;
using ToDoList.CoreTests.Logging;
using ToDoList.DataAccess.DataProviders;
using ToDoList.DataAccess.Entities;

namespace ToDoList.CoreTests
{
	[TestClass]
	public class BasicNoteTest
	{
		private BaseCrudService<BaseNote> _notesService;

		[TestInitialize]
		public void Init()
		{
			IDataProvider<List<BaseNote>> dataProvider = new JsonDataProvider<List<BaseNote>>("notesConsole.json", new ConsoleLogger());
			_notesService = BaseCrudService<BaseNote>.Create(dataProvider);
		}

		[TestMethod]
		public void TestMethod1()
		{
			IDataProvider<List<BaseNote>> dataProvider;

			//dataProvider = new XmlDataProvider<List<BaseNote>>("notesConsole.xml", new[]
			//{
			//	typeof(Note),
			//	typeof(CheckList)
			//}, new ConsoleLogger());

			dataProvider = new JsonDataProvider<List<BaseNote>>("notesConsole.json", new ConsoleLogger());
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

			Assert.IsTrue(result.State == Utils.Results.ResultState.Success, result.Exception.Message);
		}
	}
}
