using System;
using System.Collections.Generic;
using ToDoList.Core.Models;
using ToDoList.WindowsFormApp.Models.ViewModels;

namespace ToDoList.WindowsFormApp.Factories
{
	public class NotesFactory
	{
		public static INoteViewModel<TEntity> CreateViewModel<TEntity>(TEntity entity)
		{
			if (entity is CheckList)
				return new CheckListViewModel() { Entity = entity as CheckList } as INoteViewModel<TEntity>;

			if (entity is SectionedCheckList)
				return new SectionedCheckListViewModel(){Entity = entity as SectionedCheckList} as INoteViewModel<TEntity>;

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

			else if (noteType == "Sectioned Check List")
				note = new SectionedCheckList()
				{
					Id = 0,
					CreationDate = DateTime.Now,
					Sections = new List<CheckListSection>()
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