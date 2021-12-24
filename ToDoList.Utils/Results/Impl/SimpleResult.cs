using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Utils.Results.Impl
{
	public class SimpleResult : IResult
	{
		public ResultState State { get; set; }
		public Exception Exception { get; set; }
	}

	public class SimpleResult<T> : IResult<T>
	{
		public ResultState State { get; set; }
		public T ResultItem { get; set; }
		public Exception Exception { get; set; }
	}
}
