using System;

namespace ToDoList.Utils.Logging
{
	public interface ILogger
	{
		void Log(string message);
		void Log(Exception e);
	}
}