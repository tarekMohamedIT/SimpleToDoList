using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;
using ToDoList.Core.Models;
using ToDoList.Core.Utilities;

namespace ToDoList.Core.Persistence.DataProviders
{
	/// <summary>
	/// A data provider implementation for saving/loading data in XML Format.
	/// </summary>
	/// <typeparam name="T">
	/// The type of the model expected to be saved/loaded
	/// </typeparam>
	public class XmlDataProvider<T> : IDataProvider<T>
	{
		/// <inheritdoc/>
		public IEnumerable<T> Query => _table;

		/// <inheritdoc/>
		public IEnumerable<T> ReadOnlyQuery => _table;

		private readonly string _filePath;
		private List<T> _table; //List<T> instead of IEnumerable<T> for Serialization/Deserialization
		private readonly Type[] _knownTypes;
		private readonly ILogger _logger;

		/// <summary>
		/// A constructor for the XmlDataProvider with a file path and an optional logger
		/// </summary>
		/// <param name="filePath">The path of the Json file to be loaded</param>
		/// <param name="knownTypes">The Types expected to be saved/loaded in this instance</param>
		/// <param name="logger">An optional logger class for logging exceptions or messages</param>
		public XmlDataProvider(string filePath, Type[] knownTypes, ILogger logger = null)
		{
			this._filePath = filePath;
			this._knownTypes = knownTypes;
			this._logger = logger;
			LoadAll();
		}

		public void Dispose()
		{
		}

		/// <inheritdoc/>
		public void Save()
		{
			try
			{
				using (var writer = XmlWriter.Create(_filePath))
				{
					XmlSerializer xs = new XmlSerializer(typeof(List<T>), _knownTypes);
					xs.Serialize(writer, _table);
				}
				_logger?.Log("Data saved successfully");
			}
			catch (Exception e)
			{
				_logger?.Log(e);
			}
		}

		/// <summary>
		/// A method for loading all the items from the file when constructing this class.
		/// </summary>
		private void LoadAll()
		{
			try
			{
				using (var fileStream = new FileStream(_filePath, FileMode.Open))
				{

					var xs = new XmlSerializer(typeof(List<T>), _knownTypes);
					_table = xs.Deserialize(fileStream) as List<T>;
				}

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