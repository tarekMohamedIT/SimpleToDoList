using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Utils.Results;
using ToDoList.Utils.Results.Impl;

namespace ToDoList.Utils.Helpers
{
	public static class ResultsHelper
	{
		public static IResult<T> TryDo<T>(Func<T> function)
		{
			try
			{
				return new SimpleResult<T>
				{
					State = ResultState.Success,
					ResultItem = function.Invoke()
				};
			}
			catch (Exception e)
			{

				return new SimpleResult<T>
				{
					State = ResultState.Fail,
					Exception = e
				};
			}
		}

		public static IResult TryDo(Action function)
		{
			try
			{
				function.Invoke();
				return new SimpleResult
				{
					State = ResultState.Success,
				};
			}
			catch (Exception e)
			{
				return new SimpleResult
				{
					State = ResultState.Fail,
					Exception = e
				};
			}
		}
	}
}
