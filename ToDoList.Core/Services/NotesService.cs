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
			return ResultsHelper.TryDo(() => _repository.GetOne(filter));
		}

		public IResult<IEnumerable<T>> GetAll(object filter)
		{
			return ResultsHelper.TryDo(() => _repository.GetAll(filter));
		}

		public IResult<IEnumerable<T>> GetPaged(object filter, int pageNumber, int pageSize)
		{
			return ResultsHelper.TryDo(() => _repository.GetPaged(filter, pageNumber, pageSize));
		}

		public IResult Add(T entity)
		{
			return ResultsHelper.TryDo(() =>
			{
				_repository.Insert(entity);
			});
		}

		public IResult Update(T entity)
		{
			return ResultsHelper.TryDo(() =>
			{
				_repository.Update(entity);
			});
		}

		public IResult Delete(T entity)
		{
			return ResultsHelper.TryDo(() =>
			{
				_repository.Delete(entity);
			});
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
