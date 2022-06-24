using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataAccess.Entities;
using ToDoList.DataAccess.Repositories;

namespace ToDoList.Core.Services
{
	public class ChecklistNoteService : NotesService<CheckList>
	{
		private readonly IGenericRepository<ChecklistItem> checklistItemsRepository;

		public ChecklistNoteService(IGenericRepository<CheckList> repository, 
			IGenericRepository<ChecklistItem> checklistItemsRepository) : base(repository)
		{
			this.checklistItemsRepository = checklistItemsRepository;
		}

		protected override void DoInsert(CheckList entity)
		{
			var itemsList = entity.Items;
			entity.Items = null;

			base.DoInsert(entity);

			foreach (var item in itemsList)
			{
				checklistItemsRepository.Insert(item);
			}

			entity.Items = itemsList;
		}
	}
}
