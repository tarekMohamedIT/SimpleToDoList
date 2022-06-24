using System.Collections.Generic;
using ToDoList.DataAccess.Entities;
using ToDoList.DataAccess.Repositories;
using ToDoList.Utils.Helpers;
using ToDoList.Utils.Results;

namespace ToDoList.Core.Services
{
	public class NotesService<T> where T : BaseNote
	{
		private IGenericRepository<T> _repository;

		public NotesService(IGenericRepository<T> repository)
		{
			_repository = repository;
		}

		public IResult<T> GetOne(object filter)
		{
			return ResultsHelper.TryDo(() => DoGetOne(filter));
		}

		protected virtual T DoGetOne(object filter)
		{
			return _repository.GetOne(filter);
		}

		public IResult<IEnumerable<T>> GetAll(object filter)
		{
			return ResultsHelper.TryDo(() => DoGetAll(filter));
		}

		protected virtual IEnumerable<T> DoGetAll(object filter)
		{
			return _repository.GetAll(filter);
		}

		public IResult<IEnumerable<T>> GetPaged(object filter, int pageNumber, int pageSize)
		{
			return ResultsHelper.TryDo(() => DoGetPaged(filter, pageNumber, pageSize));
		}

		protected virtual IEnumerable<T> DoGetPaged(object filter, int pageNumber, int pageSize)
		{
			return _repository.GetPaged(filter, pageNumber, pageSize);
		}

		public IResult Add(T entity)
		{
			return ResultsHelper.TryDo(() =>
			{
				DoInsert(entity);
			});
		}

		protected virtual void DoInsert(T entity)
		{
			_repository.Insert(entity);
		}

		public IResult Update(T entity)
		{
			return ResultsHelper.TryDo(() =>
			{
				DoUpdate(entity);
			});
		}

		protected virtual void DoUpdate(T entity)
		{
			_repository.Update(entity);
		}

		public IResult Delete(T entity)
		{
			return ResultsHelper.TryDo(() =>
			{
				DoDelete(entity);
			});
		}

		protected virtual void DoDelete(T entity)
		{
			_repository.Delete(entity);
		}

		public IResult SaveChanges()
		{
			return ResultsHelper.TryDo(() =>
			{
				_repository.SaveChanges();
			});
		}
	}
}
