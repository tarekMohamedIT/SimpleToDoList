using System.Collections.Generic;
using System.Linq;
using ToDoList.Core.Persistence.Repositories.Concrete;
using ToDoList.DataAccess.DataProviders;
using ToDoList.DataAccess.Entities;
using ToDoList.DataAccess.Repositories;
using ToDoList.Utils.Helpers;
using ToDoList.Utils.Results;

namespace ToDoList.Core.Services
{
	public class BaseCrudService<T> where T : IEntity
	{
		/// <summary>
		/// An instance of the data provider is used to load/save data.
		/// </summary>
		private IRepository<T> _repository;
		private IDataProvider<List<T>> _provider;

		public static BaseCrudService<T> Create(IDataProvider<List<T>> provider)
		{
			var repository = new BaseRepository<T>(provider);
			return new BaseCrudService<T>(repository)
			{
				_provider = provider
			};
		}

		private BaseCrudService(IRepository<T> repository)
		{
			_repository = repository;
		}

		public IQueryable<T> Table => _repository.Table;

		public IResult<T> GetById(int id)
		{
			return ResultsHelper.TryDo(() =>
			{
				return _repository.GetById(id);
			});
		}

		public IResult Insert(T entity)
		{
			return ResultsHelper.TryDo(() =>
			{
				_repository.Insert(entity);
				_provider.Save();
			});
		}

		public IResult Insert(IEnumerable<T> entities)
		{
			return ResultsHelper.TryDo(() =>
			{
				_repository.Insert(entities);
				_provider.Save();
			});
		}

		public IResult Update(T entity)
		{
			return ResultsHelper.TryDo(() =>
			{
				_repository.Update(entity);
				_provider.Save();
			});
		}

		public IResult Update(IEnumerable<T> entities)
		{
			return ResultsHelper.TryDo(() =>
			{
				_repository.Update(entities);
				_provider.Save();
			});
		}

		public IResult Delete(T entity)
		{
			return ResultsHelper.TryDo(() =>
			{
				_repository.Delete(entity);
				_provider.Save();
			});
		}

		public IResult Delete(IEnumerable<T> entities)
		{
			return ResultsHelper.TryDo(() =>
			{
				_repository.Delete(entities);
			});
		}
	}
}
