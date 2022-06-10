namespace ToDoList.DataAccess.Entities
{
	public class ChecklistItem : BaseNote
	{
		public int NoteId { get; set; }
		public int SectionId { get; set; }
		public bool Checked { get; set; }
	}
}