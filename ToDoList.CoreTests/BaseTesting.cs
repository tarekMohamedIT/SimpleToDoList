using System.Runtime.ExceptionServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.DataAccess.Entities;
using ToDoList.Utils.Results;

namespace ToDoList.CoreTests
{
	public class BaseTesting
	{
		protected void AssertTrue(IResult result)
		{
			if (result.Exception != null)
			{
				ExceptionDispatchInfo.Capture(result.Exception).Throw();
				return;
			}

			Assert.IsTrue(result.State == Utils.Results.ResultState.Success, result.Exception?.ToString() ?? "Success");
		}
	}
}