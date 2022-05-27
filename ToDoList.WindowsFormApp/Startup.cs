using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core;
using ToDoList.Core.Services;
using ToDoList.DataAccess.DataProviders;
using ToDoList.DataAccess.Entities;

namespace ToDoList.WindowsFormApp
{
	class Startup
	{
		public void RegisterServices(AppServicesResolver appServices)
		{
			appServices.Register<IDataProvider<List<BaseNote>>>(() => new XmlDataProvider<List<BaseNote>>("notesList.xml", new Type[]
			{
				typeof(Note),
				typeof(CheckList),
				typeof(SectionedCheckList),
			}, new FormsLogger()));

			appServices.Register<BaseCrudService<BaseNote>>(() =>
			{
				var _noteProvider = AppServicesResolver.Current.Resolve<IDataProvider<List<BaseNote>>>();
				return BaseCrudService<BaseNote>.Create(_noteProvider);
			});
		}
	}
}
