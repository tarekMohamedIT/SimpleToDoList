using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.DataAccess.DataProviders
{
	public class MemoryDataProvider<T> : IDataProvider<T> where T : class, new()
	{
		public T Item { get; set; }

		public MemoryDataProvider(T item)
		{
			this.Item = item;
		}

		public void Dispose()
		{
			
		}

		public T Load()
		{
			return Item ?? (Item = new T());
		}

		public void Save()
		{
			
		}
	}
}
