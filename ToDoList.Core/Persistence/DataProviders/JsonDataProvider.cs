using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ToDoList.Core.Utilities;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ToDoList.Core.Persistence.DataProviders
{
	public class JsonDataProvider<T> : IDataProvider<T>
	{
		public IEnumerable<T> Query => _table;

		public IEnumerable<T> ReadOnlyQuery => _table;

		private readonly string _filePath;
		private List<T> _table;
		private readonly ILogger _logger;

		public JsonDataProvider(string filePath, ILogger logger = null)
		{
			this._filePath = filePath;
			this._logger = logger;
			LoadAll();
		}

		public void Save()
		{
			try
			{
				var jsonString = JsonConvert.SerializeObject(_table, Formatting.Indented, new JsonSerializerSettings
				{
					TypeNameHandling = TypeNameHandling.All
				});
				File.WriteAllText(_filePath, jsonString);

				_logger?.Log("Data saved successfully");
			}

			catch (Exception e)
			{
				_logger?.Log(e);
			}
		}

		public void Dispose()
		{
			
		}

		private void LoadAll()
		{
			try
			{
				_table = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(_filePath), new JsonSerializerSettings
				{
					TypeNameHandling = TypeNameHandling.All
				});
				_logger?.Log("Data loaded successfully");
			}
			catch (Exception e)
			{
				_logger?.Log(e);
				_table = new List<T>();
			}
		}
	}
}