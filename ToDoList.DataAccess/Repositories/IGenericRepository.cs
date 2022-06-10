using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataAccess.Entities;

namespace ToDoList.DataAccess.Repositories
{
	public interface IGenericRepository<TEntity> : IDisposable where TEntity : IEntity
	{
		TEntity GetOne(object filterModel);

		IEnumerable<TEntity> GetAll(object filterModel);
		IEnumerable<TEntity> GetPaged(object filterModel, int pageNumber, int pageSize);

		void Insert(TEntity entity);
		void Update(TEntity entity);
		void Delete(TEntity entity);
		void Delete(IEnumerable<TEntity> entities);

		void SaveChanges();
	}
}
