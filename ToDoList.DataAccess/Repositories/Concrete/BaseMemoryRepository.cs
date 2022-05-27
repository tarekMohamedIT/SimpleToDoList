using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.DataAccess.DataProviders;
using ToDoList.DataAccess.Entities;
using ToDoList.DataAccess.Repositories;

namespace ToDoList.Core.Persistence.Repositories.Concrete
{
	/// <summary>
	/// An implementation for the Generic IRepository, Using a data provider for data loading/saving.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class BaseMemoryRepository<T> : IRepository<T> where T : IEntity
	{
		/// <summary>
		/// An instance of the data provider is used to load/save data.
		/// </summary>
		private IDataProvider<List<T>> _provider;

		public BaseMemoryRepository(IDataProvider<List<T>> provider)
		{
			this._provider = provider;
			_table = _provider != null ? _provider.Load() : new List<T>();
		}

		/// <summary>
		/// The table's query, either from the data provider or creates a new list.
		/// </summary>
		public IQueryable<T> Table
		{
			get
			{
				if (_table == null)
				{
					_table = _provider != null ? _provider.Load() : new List<T>();
				}

				return _table.AsQueryable();
			}
		}
		protected List<T> _table;

		/// <inheritdoc cref="IRepository{TEntity}.GetById"/>>
		public T GetById(int id)
		{
			return Table.FirstOrDefault(i => i.Id == id);
		}

		/// <inheritdoc cref="IRepository{TEntity}.Insert(TEntity)"/>
		public void Insert(T entity)
		{
			if (entity.Id == 0)
				entity.Id = GetNextId();
			_table.Add(entity);
		}

		/// <inheritdoc cref="IRepository{TEntity}.Insert(IEnumerable{TEntity})"/>
		public void Insert(IEnumerable<T> entities)
		{
			foreach (var entity in entities)
			{
				Insert(entity);
			}
		}

		/// <inheritdoc cref="IRepository{TEntity}.Update(TEntity)"/>
		public void Update(T entity)
		{
			var existed = _table.FindIndex(t => t.Id == entity.Id);

			if (existed == -1)
				throw new ArgumentException();

			_table[existed] = entity;
		}

		/// <inheritdoc cref="IRepository{TEntity}.Update(IEnumerable{TEntity})"/>
		public void Update(IEnumerable<T> entities)
		{
			foreach (var entity in entities)
			{
				var existed = _table.FindIndex(t => t.Id == entity.Id);

				if (existed == -1)
					throw new ArgumentException();

				_table[existed] = entity;
			}
		}

		/// <inheritdoc cref="IRepository{TEntity}.Delete(TEntity)"/>
		public void Delete(T entity)
		{
			_table.Remove(entity);
		}

		/// <inheritdoc cref="IRepository{TEntity}.Delete(IEnumerable{TEntity})"/>
		public void Delete(IEnumerable<T> entities)
		{
			_table.RemoveAll(entities.Contains);
		}

		/// <summary>
		/// A method for generating an Id for the next item in the list
		/// </summary>
		/// <returns>an int indicating the next item's Id</returns>
		private int GetNextId()
		{
			return _table.Count;
		}
	}
}
