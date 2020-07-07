using System;
using System.Collections.Generic;

namespace ToDoList.Core.Persistence.DataProviders
{
	/// <summary>
	/// An interface Used for saving and loading data from a data source. 
	/// </summary>
	/// <typeparam name="T">
	/// The type of the model expected to be saved/loaded
	/// </typeparam>
	public interface IDataProvider<out T> : IDisposable
	{
		/// <summary>
		/// An IEnumerable for the data list loaded into this instance.
		/// </summary>
		IEnumerable<T> Query { get; }

		/// <summary>
		/// A Read-Only IEnumerable for the data list loaded into this instance.
		/// </summary>
		IEnumerable<T> ReadOnlyQuery { get; }

		/// <summary>
		/// A method for saving data into the data source.
		/// </summary>
		void Save();
	}
}