using System;

namespace ToDoList.Utils.Results.Impl
{
	public class SimpleResult : IResult
	{
		public ResultState State { get; set; }
		public Exception Exception { get; set; }
	}

	public class SimpleResult<T> : IResult<T>
	{
		private T _resultItem;
		public ResultState State { get; set; }

		public static implicit operator SimpleResult<T>(T item) => new SimpleResult<T>
		{
			State = ResultState.Success,
			ResultItem = item
		};
	
		public T ResultItem
		{
			get
			{
				if (Exception != null)
				{
					System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture(Exception).Throw();
				}

				return _resultItem;
			}
			set => _resultItem = value;
		}
		public Exception Exception { get; set; }
	}
}
