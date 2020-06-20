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

		private string _filePath;
		private List<T> _table;
		private Type[] _knownTypes;

		public XmlDataProvider(string filePath, Type[] knownTypes)
		{
			this._filePath = filePath;
			this._knownTypes = knownTypes;
			LoadAll();
		}

		public void Dispose()
		{
		}

		public void Save()
		{
			using (var writer = XmlWriter.Create(_filePath))
			{
				XmlGenericSerializer.Serialize(this._table, writer, _knownTypes);
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
			}
			catch (Exception e)
			{
				_table = new List<T>();
			}
		}
	}
}