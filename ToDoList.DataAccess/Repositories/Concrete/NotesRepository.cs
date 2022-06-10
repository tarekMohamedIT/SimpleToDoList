using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataAccess.DataProviders;
using ToDoList.DataAccess.Entities;
using ToDoList.DataAccess.Filters;

namespace ToDoList.DataAccess.Repositories.Concrete
{
	public class NotesRepository<T> : BaseMemoryRepository<T> where T : BaseNote
	{
		public NotesRepository(IDataProvider<List<T>> provider) : base(provider)
		{
		}

		protected override IEnumerable<T> DoFilter(object filterModel, IEnumerable<T> query)
		{
			if (filterModel == null) return query;

			var filter = (BaseNoteFilter)filterModel;

			if (filter.Id != null) query = query.Where(x => x.Id == filter.Id);
			if (filter.Title != null) query = query.Where(x => x.Title == filter.Title);
			if (filter.CreationDate != null) query = query.Where(x => x.CreationDate == filter.CreationDate);

			return query;
		}
	}
}
