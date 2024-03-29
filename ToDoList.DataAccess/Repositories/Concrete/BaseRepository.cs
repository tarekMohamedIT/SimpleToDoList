﻿using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.DataAccess.DataProviders;
using ToDoList.DataAccess.Entities;
using ToDoList.DataAccess.Repositories;

namespace ToDoList.Core.Persistence.Repositories.Concrete
{
	public class BaseRepository<T> : IRepository<T> where T : IEntity
	{
		private IDataProvider<List<T>> _provider;

		public BaseRepository(IDataProvider<List<T>> provider)
		{
			this._provider = provider;
			_table = _provider != null ? _provider.Load() : new List<T>();
		}
		
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

		public T GetById(int id)
		{
			return Table.FirstOrDefault(i => i.Id == id);
		}
		
		public void Insert(T entity)
		{
			if (entity.Id == 0)
				entity.Id = GetNextId();
			_table.Add(entity);
		}
		
		public void Insert(IEnumerable<T> entities)
		{
			foreach (var entity in entities)
			{
				Insert(entity);
			}
		}
		
		public void Update(T entity)
		{
			var existed = _table.FindIndex(t => t.Id == entity.Id);

			if (existed == -1)
				throw new ArgumentException();

			_table[existed] = entity;
		}
		
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
		
		public void Delete(T entity)
		{
			_table.Remove(entity);
		}
		
		public void Delete(IEnumerable<T> entities)
		{
			_table.RemoveAll(entities.Contains);
		}
		
		private int GetNextId()
		{
			return _table.Count;
		}
	}
}
