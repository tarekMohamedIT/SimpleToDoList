using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core;
using ToDoList.Core.Services;
using ToDoList.DataAccess.DataProviders;
using ToDoList.DataAccess.Entities;
using ToDoList.DataAccess.Repositories;
using ToDoList.DataAccess.Repositories.Concrete;
using ToDoList.Utils.Logging;

namespace ToDoList.WindowsFormApp
{
	class Startup
	{
		public void RegisterServices(AppServicesResolver appServices)
		{
			appServices.Register<ILogger>(() => new FormsLogger())
				
				.Register<IDataProvider<List<BaseNote>>>(() => new XmlDataProvider<List<BaseNote>>("notesList.xml", new Type[]
				{
					typeof(Note),
					typeof(CheckList),
					typeof(SectionedCheckList),
				}, appServices.Resolve<ILogger>()))
			
			.Register<IGenericRepository<BaseNote>>(() => new NotesRepository<BaseNote>(appServices.Resolve<IDataProvider<List<BaseNote>>>()));
		}
	}
}
