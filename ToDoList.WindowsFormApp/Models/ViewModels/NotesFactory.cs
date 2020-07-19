using System;
using System.Collections.Generic;
using ToDoList.Core.Models;

namespace ToDoList.WindowsFormApp.Models.ViewModels
{
	public class NotesFactory
	{
		public static INoteViewModel<TEntity> CreateViewModel<TEntity>(TEntity entity)
		{
			if (entity is CheckList)
				return new CheckListViewModel() { Entity = entity as CheckList } as INoteViewModel<TEntity>;

			return new SimpleNoteViewModel() { Entity = entity as Note } as INoteViewModel<TEntity>;
		}

		public static BaseNote CreateNoteModel(string noteType)
		{
			BaseNote note;

			if (noteType == "Check List")
				note = new CheckList()
				{
					Id = 0,
					CreationDate = DateTime.Now,
					Items = new List<ChecklistItem>()
				};

			else
				note = new Note()
				{
					Id = 0,
					CreationDate = DateTime.Now,
				};

			return note;
		}
	}
}