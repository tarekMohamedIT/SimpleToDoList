using System;
using System.Collections.Generic;
using ToDoList.Core.Models;

namespace ToDoList.WindowsFormApp.ViewModels
{
	public class NotesFactory
	{
		public static INoteViewModel<TEntity> Create<TEntity>(TEntity entity)
		{
			if (entity is CheckList)
				return new CheckListViewModel() { Entity = entity as CheckList } as INoteViewModel<TEntity>;

			return new SimpleNoteViewModel() { Entity = entity as Note } as INoteViewModel<TEntity>;
		}

		public static BaseNote Create(string noteType, int id)
		{
			BaseNote note;

			if (noteType == "Check List")
				note = new CheckList()
				{
					Id = id,
					CreationDate = DateTime.Now,
					Items = new List<ChecklistItem>()
				};

			else
				note = new Note()
				{
					Id = id,
					CreationDate = DateTime.Now,
				};

			return note;
		}
	}
}