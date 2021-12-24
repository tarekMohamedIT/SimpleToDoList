using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

		public BaseCrudService(IRepository<T> repository)
		{
			_repository = repository;
		}

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
			});
		}

		public IResult Insert(IEnumerable<T> entities)
		{
			return ResultsHelper.TryDo(() =>
			{
				_repository.Insert(entities);
			});
		}

		public IResult Update(T entity)
		{
			return ResultsHelper.TryDo(() =>
			{
				_repository.Update(entity);
			});
		}

		public IResult Update(IEnumerable<T> entities)
		{
			return ResultsHelper.TryDo(() =>
			{
				_repository.Update(entities);
			});
		}

		public IResult Delete(T entity)
		{
			return ResultsHelper.TryDo(() =>
			{
				_repository.Delete(entity);
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
