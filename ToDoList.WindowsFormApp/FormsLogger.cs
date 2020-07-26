using System;
using System.Windows.Forms;
using ToDoList.Core.Utilities;

namespace ToDoList.WindowsFormApp
{
	public class FormsLogger : ILogger
	{
		public void Log(string message)
		{
			MessageBox.Show(DateTime.Now.ToString("yy-MMM-dd HH:mm:ss") + " : " + message);
		}

		public void Log(Exception e)
		{
			string exceptionMessage = "";

			do
			{
				exceptionMessage += "msg :" + e.Message + "\n";
			} while ((e = e.InnerException) != null);
			Log(exceptionMessage);
		}
	}
}