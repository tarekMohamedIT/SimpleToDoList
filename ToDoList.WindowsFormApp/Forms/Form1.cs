using System;
using System.Linq;
using System.Windows.Forms;
using ToDoList.Core.Models;
using ToDoList.Core.Persistence.DataProviders;
using ToDoList.Core.Persistence.Repositories;
using ToDoList.Core.Persistence.Repositories.Concrete;
using ToDoList.WindowsFormApp.Forms.Popups;
using ToDoList.WindowsFormApp.ViewModels;

namespace ToDoList.WindowsFormApp.Forms
{
	public partial class Form1 : Form
	{
		private IRepository<BaseNote> _notesRepository;
		private IDataProvider<BaseNote> _noteProvider;
		private INoteViewModel _currentNoteViewModel;

		public Form1()
		{
			InitializeComponent();
			_noteProvider = new XmlDataProvider<BaseNote>("notesList.xml", new Type[]
			{
				typeof(Note),
				typeof(CheckList)
			});
			_notesRepository = new BaseMemoryRepository<BaseNote>(_noteProvider);

			var notesList = _notesRepository.Table.ToList();
			foreach (var note in notesList)
			{
				listBox1.Items.Add(note.CreationDate.ToString("yyyy/MM/dd HH:mm:ss"));
			}

			if (notesList.Count > 0)
				listBox1.SelectedIndex = 0;
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			var note = _notesRepository.Table.ToList()[listBox1.SelectedIndex];

			_currentNoteViewModel = NotesFactory.Create(note);

			_currentNoteViewModel.InitControl(flowLayoutPanel1);

			label3.Text = $@"Date : {note.CreationDate:yyyy/MM/dd HH:mm:ss}";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//var note = _notesRepository.Table.ToList()[listBox1.SelectedIndex];
			//note.Name = textBox1.Text;
			//note.Text = textBox2.Text;

			_notesRepository.Update(_currentNoteViewModel.Entity as BaseNote);
			_noteProvider.Save();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			var addForm = new SelectNoteTypeForm();
			addForm.ShowDialog();

			var note = NotesFactory.Create(addForm.selectedItem, listBox1.SelectedIndex + 1);

			_notesRepository.Insert(note);
			listBox1.Items.Add(note.CreationDate.ToString("yyyy/MM/dd HH:mm:ss"));
			listBox1.SelectedIndex = note.Id;
		}
	}
}
