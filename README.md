# SimpleToDoList
A simple windows form application for notes taking.
This simple C# application aims to enhance C# developers' skills and knowledge by providing a "playground" to build upon and try out new things.

# Featuring

* Multi-project architecture (Merged data access and business logic layers just for simplicity, you are free to create a new layer for database access).
  * The [ToDoList.Core] contains all the entities, business and database access logic.
  * The [ToDoList.TestConsole] Contains the simplest scenario where a user loads the data from a file, inserts some items and saves them in the same file.
  * The [ToDoList.WindowsFormApp] Serves as the main UI project (A windows form application), containing view models and forms for UI
  experiece with the capabilities of the sysetm.
* Well-documented Core project (tried to explain everything in it to my best effort).
* An [IEntity] interface for all entities to inherit from (For database access).
* An [IDataProvider] to provide a Save/Load mechanic for the repository pattern.
  *There are currently 2 implementations for this interface: [XmlDataProvider] and [JsonDataProvider]
* A generic [IRepository] to provide a unified way for inserting, updating and deleting data items 
  * You can create your own specific repository by exteding the [BaseMemoryRepository]
* \[NEW\] A sub menu system for adding new features to the windows form project.
* \[NEW\] A theme mechanism for the windows form project, You can create and update your own themes for the notes application.
  
# Extensions to be implemented

You can add more features to this project like :
* A Simple ASP .NET UI project serves as a server-side notes tracking application and an API to access it.
* A User's specific notes list with a Login/Register pages.
* A new implementation of IDataProvider using EntityFramework or Microsoft Access (Even MongoDB or My SQL ?)
* Notes' categories, serves as a notenook with a list of notes in it.

# Final Thoughts
I 've built this project to be my own personal playground to test new ideas and explore the extend of my knowledge, even applying new principles learned during long hours
of research and trial-and-error.

Also I didn't add any license to this project because it is not even close to a production-ready application.

So download the project, learn new stuff, apply it and have fun!

[ToDoList.Core]: https://github.com/tarekMohamedIT/SimpleToDoList/tree/master/ToDoList.Core
[ToDoList.TestConsole]: https://github.com/tarekMohamedIT/SimpleToDoList/tree/master/ToDoList.TestConsole
[ToDoList.WindowsFormApp]: https://github.com/tarekMohamedIT/SimpleToDoList/tree/master/ToDoList.WindowsFormApp
[IEntity]: https://github.com/tarekMohamedIT/SimpleToDoList/blob/master/ToDoList.Core/Models/IEntity.cs
[IDataProvider]: https://github.com/tarekMohamedIT/SimpleToDoList/blob/master/ToDoList.Core/Persistence/DataProviders/IDataProvider.cs
[IRepository]: https://github.com/tarekMohamedIT/SimpleToDoList/blob/master/ToDoList.Core/Persistence/Repositories/IRepository.cs
[BaseMemoryRepository]: https://github.com/tarekMohamedIT/SimpleToDoList/blob/master/ToDoList.Core/Persistence/Repositories/Concrete/BaseMemoryRepository.cs
[XmlDataProvider]: https://github.com/tarekMohamedIT/SimpleToDoList/blob/master/ToDoList.Core/Persistence/DataProviders/XmlDataProvider.cs
[JsonDataProvider]: https://github.com/tarekMohamedIT/SimpleToDoList/blob/master/ToDoList.Core/Persistence/DataProviders/JsonDataProvider.cs
