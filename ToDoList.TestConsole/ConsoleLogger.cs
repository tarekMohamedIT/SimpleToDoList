using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.Utilities;

namespace ToDoList.TestConsole
{
	public class ConsoleLogger : ILogger
	{
		public void Log(string message)
		{
			Console.WriteLine(DateTime.Now.ToString("yyyy MMMM dd HH:mm:ss") + " : " + message);
		}

		public void Log(Exception e)
		{
			string exceptionMessage = DateTime.Now.ToString("yyyy MMMM dd HH:mm:ss") +" : ";

			do
			{
				exceptionMessage += "msg :" + e.Message + "\n";
			} while ((e = e.InnerException) != null);

			Console.WriteLine(exceptionMessage);
		}
	}
}
