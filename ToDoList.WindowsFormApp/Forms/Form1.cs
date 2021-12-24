using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ToDoList.Core.Persistence.Repositories.Concrete;
using ToDoList.DataAccess.DataProviders;
using ToDoList.DataAccess.Entities;
using ToDoList.DataAccess.Repositories;
using ToDoList.WindowsFormApp.Contexts;
using ToDoList.WindowsFormApp.Factories;
using ToDoList.WindowsFormApp.Forms.Popups;
using ToDoList.WindowsFormApp.Models.ViewModels;

namespace ToDoList.WindowsFormApp.Forms
{
	public partial class Form1 : Form
	{
		private IRepository<BaseNote> _notesRepository;
		private IDataProvider<List<BaseNote>> _noteProvider;
		private INoteViewModel _currentNoteViewModel;

		public Form1()
		{
			InitializeComponent();
			_noteProvider = new XmlDataProvider<List<BaseNote>>("notesList.xml", new Type[]
			{
				typeof(Note),
				typeof(CheckList),
				typeof(SectionedCheckList),
			}, new FormsLogger());
			_notesRepository = new BaseMemoryRepository<BaseNote>(_noteProvider);

			var notesList = _notesRepository.Table.ToList();
			int count = 0;
			foreach (var note in notesList)
			{
				if (FormsContext.Instance.Settings.UseTitleForNotesList)
					listBox1.Items.Add(note.Title);

				else listBox1.Items.Add((count++).ToString("D5"));

			}

			if (notesList.Count > 0)
				listBox1.SelectedIndex = 0;
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			var note = _notesRepository.Table.ToList()[listBox1.SelectedIndex];

			_currentNoteViewModel = NotesFactory.CreateViewModel(note);
			_currentNoteViewModel.InitControl(flowLayoutPanel1);

			label3.Text = $@"Date : {note.CreationDate:yyyy/MM/dd HH:mm:ss}";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			_notesRepository.Update(_currentNoteViewModel.Entity as BaseNote);
			_noteProvider.Save();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			var addForm = new SelectNoteTypeForm();
			addForm.ShowDialog();

			var note = NotesFactory.CreateNoteModel(addForm.selectedItem);

			_notesRepository.Insert(note);
			listBox1.Items.Add(note.Id.ToString("D5"));
			listBox1.SelectedIndex = note.Id;
		}
	}
}
