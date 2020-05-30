using System;
using System.Collections.Generic;

namespace ToDoList.Core.Persistence.DataProviders
{
	public interface IDataProvider<out T> : IDisposable
	{
		IEnumerable<T> Query { get; }
		IEnumerable<T> ReadOnlyQuery { get; }

		void Save();
	}
}