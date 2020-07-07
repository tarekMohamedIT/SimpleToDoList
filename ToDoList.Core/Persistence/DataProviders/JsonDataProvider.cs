using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ToDoList.Core.Utilities;

namespace ToDoList.Core.Persistence.DataProviders
{
	/// <summary>
	/// A data provider implementation for saving/loading data in JSON Format.
	/// </summary>
	/// <typeparam name="T">
	/// The type of the model expected to be saved/loaded
	/// </typeparam>
	public class JsonDataProvider<T> : IDataProvider<T>
	{
		/// <inheritdoc/>
		public IEnumerable<T> Query => _table;

		/// <inheritdoc/>
		public IEnumerable<T> ReadOnlyQuery => _table;

		private readonly string _filePath;
		private List<T> _table; //List<T> instead of IEnumerable<T> for Serialization/Deserialization
		private readonly ILogger _logger;

		/// <summary>
		/// A constructor for the JsonDataProvider with a file path and an optional logger
		/// </summary>
		/// <param name="filePath">The path of the Json file to be loaded</param>
		/// <param name="logger">An optional logger class for logging exceptions or messages</param>
		public JsonDataProvider(string filePath, ILogger logger = null)
		{
			this._filePath = filePath;
			this._logger = logger;
			LoadAll();
		}

		/// <inheritdoc/>
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

		/// <summary>
		/// A method for loading all the items from the file when constructing this class.
		/// </summary>
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