using System;
using System.Collections.Generic;

namespace ToDoList.Core.Persistence.DataProviders
{
	public interface IProvider<out T> : IDisposable
	{
		IEnumerable<T> Query { get; }
		IEnumerable<T> ReadOnlyQuery { get; }

		void Save();
	}
}