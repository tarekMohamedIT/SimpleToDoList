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
	public class XmlDataProvider<T> : IDataProvider<T>
	{
		public IEnumerable<T> Query => _table;
		public IEnumerable<T> ReadOnlyQuery => _table;

		private readonly string _filePath;
		private List<T> _table;
		private readonly Type[] _knownTypes;
		private readonly ILogger _logger;

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