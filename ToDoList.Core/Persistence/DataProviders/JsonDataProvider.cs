using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ToDoList.Core.Persistence.DataProviders
{
	public class JsonDataProvider<T> : IDataProvider<T>
	{
		public IEnumerable<T> Query => _table;

		public IEnumerable<T> ReadOnlyQuery => _table;

		private string _filePath;
		private List<T> _table;

		public JsonDataProvider(string filePath)
		{
			this._filePath = filePath;
			LoadAll();
		}

		public void Save()
		{
			var jsonString = JsonSerializer.Serialize(_table);
			File.WriteAllText(_filePath, jsonString);
		}

		public void Dispose()
		{
			
		}

		private void LoadAll()
		{
			try
			{
				_table = JsonSerializer.Deserialize<List<T>>(File.ReadAllText(_filePath));
			}
			catch (Exception e)
			{
				_table = new List<T>();
			}
		}
	}
}