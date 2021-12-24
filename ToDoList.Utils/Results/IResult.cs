using System;

namespace ToDoList.Utils.Results
{
	public interface IResult
	{
		ResultState State { get; }
		Exception Exception { get; }
	}

	public interface IResult<T> : IResult
	{
		T ResultItem { get; }
	}
}
