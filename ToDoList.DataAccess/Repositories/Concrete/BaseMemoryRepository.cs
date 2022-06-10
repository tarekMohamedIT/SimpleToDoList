using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataAccess.DataProviders;
using ToDoList.DataAccess.Entities;

namespace ToDoList.DataAccess.Repositories.Concrete
{
	public abstract class BaseMemoryRepository<T> : IGenericRepository<T>, IDisposable where T : IEntity
	{
		private IDataProvider<List<T>> _provider;

		public BaseMemoryRepository(IDataProvider<List<T>> provider)
		{
			this._provider = provider;
		}

		public T GetOne(object filterModel)
		{
			return FilterItems(filterModel).FirstOrDefault();
		}

		private IEnumerable<T> FilterItems(object filterModel)
		{
			return DoFilter(filterModel, GetTable());
		}

		protected abstract IEnumerable<T> DoFilter(object filterModel, IEnumerable<T> enumerable);

		private List<T> GetTable()
		{
			return _provider != null
				? _provider.Load() 
				: throw new InvalidOperationException("Data provider must not be nullable");
		}

		public IEnumerable<T> GetAll(object filterModel)
		{
			return FilterItems(filterModel)
				.ToList();
		}

		public IEnumerable<T> GetPaged(object filterModel, int pageNumber, int pageSize)
		{
			return FilterItems(filterModel)
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToList();
		}

		public void Insert(T entity)
		{
			var items = GetTable();
			if (entity.Id == 0)
				entity.Id = GetNextId();
			items.Add(entity);
		}

		private int GetNextId()
		{
			var lastItem = GetTable().LastOrDefault();

			return lastItem != null ? lastItem.Id + 1 : 1;
		}

		public void Update(T entity)
		{
			var table = GetTable();
			var existed = table.FindIndex(t => t.Id == entity.Id);

			if (existed == -1)
				throw new ArgumentException();

			table[existed] = entity;
		}

		public void Delete(T entity)
		{
			GetTable().Remove(entity);
		}

		public void Delete(IEnumerable<T> entities)
		{
			foreach (var item in entities)
			{
				Delete(item);
			}
		}

		public void Dispose()
		{
			_provider.Save();
		}

		public void SaveChanges()
		{
			_provider.Save();
		}
	}
}
