using System.Linq;
using ToDoList.Core.Models;

namespace ToDoList.Core.Persistence.Repositories
{
	/// <summary>
	/// An interface for a generic Repository pattern to be used for EntityFramework's repositories
	/// with a query for the no tracking query
	/// </summary>
	/// <typeparam name="TEntity">This interface requires an IEntity for the Id property</typeparam>
	public interface IEFRepository<TEntity> : IRepository<TEntity> where TEntity : IEntity
	{
		/// <summary>
		/// The Read-Only no tracking table query to be used in extended queries to the data source.
		/// </summary>
		IQueryable<TEntity> TableNoTracking { get; }
	}
}