namespace ToDoList.Core.Models
{
	/// <summary>
	/// A common interface used for the repository pattern.
	/// Uses an int Id for identification.
	/// </summary>
	public interface IEntity
	{
		/// <summary>
		/// The Id of this entity
		/// </summary>
		int Id { get; set; }
	}
}