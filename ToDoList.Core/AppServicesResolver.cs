using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Core
{
	public class AppServicesResolver
	{
		private static AppServicesResolver _instance;
		private IDictionary<string, Func<object>> factories;
		public static AppServicesResolver Current => _instance ?? (_instance = new AppServicesResolver());

		public AppServicesResolver()
		{
			factories = new ConcurrentDictionary<string, Func<object>>();
		}

		public AppServicesResolver Register<T>(Func<object> creationFactory) where T : class
		{
			return Register(typeof(T), creationFactory);
		}

		public AppServicesResolver Register(Type type, Func<object> creationFactory)
		{
			var typeName = type.FullName;
			return Register(typeName, creationFactory);
		}


		public AppServicesResolver Register(string typeName, Func<object> creationFactory)
		{
			if (factories.ContainsKey(typeName)) factories[typeName] = creationFactory;
			else factories.Add(typeName, creationFactory);

			return this;
		}

		public T Resolve<T>() where T : class
		{
			return (T)Resolve(typeof(T));
		}

		public object Resolve(Type type)
		{
			var typeName = type.FullName;
			return Resolve(typeName);
		}

		public object Resolve(string typeName)
		{
			if (factories.ContainsKey(typeName)) return factories[typeName].Invoke();

			return null;
		}
	}
}
