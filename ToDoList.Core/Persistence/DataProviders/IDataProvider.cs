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
	public interface IDataProvider<T> : IDisposable
	{
		
		/// <summary>
		/// A method for saving data into the data source.
		/// </summary>
		void Save();

		T Load();
		T Item { get; set; } //List<T> instead of IEnumerable<T> for Serialization/Deserialization
	}
}