using System.Linq;
using ToDoList.Core.Models;

namespace ToDoList.Core.Persistence.Repositories
{
	public interface IEFRepository<TEntity> : IRepository<TEntity> where TEntity : IEntity
	{
		IQueryable<TEntity> TableNoTracking { get; }
	}
}