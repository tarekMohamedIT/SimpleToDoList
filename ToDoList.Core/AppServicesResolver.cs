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
		private IDictionary<Type, Func<object>> factories;
		public static AppServicesResolver Current => _instance ?? (_instance = new AppServicesResolver());

		public AppServicesResolver()
		{
			factories = new ConcurrentDictionary<Type, Func<object>>();
		}

		public AppServicesResolver Register<T>(Func<object> creationFactory) where T : class
		{
			return Register(typeof(T), creationFactory);
		}

		public AppServicesResolver Register(Type type, Func<object> creationFactory)
		{
			if (factories.ContainsKey(type)) factories[type] = creationFactory;
			else factories.Add(type, creationFactory);

			return this;
		}

		public T Resolve<T>() where T : class
		{
			return (T)Resolve(typeof(T));
		}

		public object Resolve(Type type)
		{
			if (factories.ContainsKey(type)) return factories[type].Invoke();

			return null;
		}
	}
}
