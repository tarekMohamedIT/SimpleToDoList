using System.Collections.Generic;
using System.Linq;
using ToDoList.Core.Models;

namespace ToDoList.Core.Persistence.Repositories
{
	public interface IRepository<TEntity> where TEntity : IEntity
	{
		IQueryable<TEntity> Table { get; }

		TEntity GetById(int id);

		void Insert(TEntity entity);

		void Insert(IEnumerable<TEntity> entities);

		void Update(TEntity entity);

		void Update(IEnumerable<TEntity> entities);

		void Delete(TEntity entity);

		void Delete(IEnumerable<TEntity> entities);
	}
}