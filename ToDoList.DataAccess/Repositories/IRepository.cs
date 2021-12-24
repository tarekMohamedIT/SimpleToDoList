using System.Collections.Generic;
using System.Linq;
using ToDoList.DataAccess.Entities;

namespace ToDoList.DataAccess.Repositories
{
	/// <summary>
	/// An interface for a generic Repository pattern to be used in all Implemented repositories.
	/// </summary>
	/// <typeparam name="TEntity">This interface requires an IEntity for the Id property</typeparam>
	public interface IRepository<TEntity> where TEntity : IEntity
	{
		/// <summary>
		/// The table query to be used in extended queries to the data source.
		/// </summary>
		IQueryable<TEntity> Table { get; }

		/// <summary>
		/// Get an element by the Id property.
		/// </summary>
		/// <param name="id">The Id of that element in the data source</param>
		/// <returns>An element of the specified type or should return the default value if the item does not exist</returns>
		TEntity GetById(int id);

		/// <summary>
		/// Adds a new element to the data source.
		/// </summary>
		/// <param name="entity"> The element to be added.</param>
		void Insert(TEntity entity);

		/// <summary>
		/// Adds a list of elements to the data source.
		/// </summary>
		/// <param name="entities">The list of elements to be added</param>
		void Insert(IEnumerable<TEntity> entities);

		/// <summary>
		/// Updates an element from the data source.
		/// </summary>
		/// <param name="entity">The item to be updated</param>
		void Update(TEntity entity);

		/// <summary>
		/// Updates a list of elements from the data source.
		/// </summary>
		/// <param name="entities">The list of elements to be updated</param>
		void Update(IEnumerable<TEntity> entities);

		/// <summary>
		/// Deletes an element from the data source.
		/// </summary>
		/// <param name="entity">The item to be deleted</param>
		void Delete(TEntity entity);

		/// <summary>
		/// Deletes a list of elements from the data source.
		/// </summary>
		/// <param name="entities">The list of elements to be deleted</param>
		void Delete(IEnumerable<TEntity> entities);
	}
}