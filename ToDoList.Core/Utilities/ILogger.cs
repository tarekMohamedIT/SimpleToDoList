using System;

namespace ToDoList.Core.Utilities
{
	public interface ILogger
	{
		void Log(string message);
		void Log(Exception e);
	}
}