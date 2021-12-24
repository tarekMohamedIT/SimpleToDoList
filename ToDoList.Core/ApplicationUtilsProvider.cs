using ToDoList.Utils.Logging;

namespace ToDoList.Core
{
	public static class ApplicationUtilsProvider
	{
		public static ILogger Logger { get; private set; }

		static ApplicationUtilsProvider()
		{
		}

		public static void Register(ILogger logger)
		{
			Logger = logger;
		}
	}
}
