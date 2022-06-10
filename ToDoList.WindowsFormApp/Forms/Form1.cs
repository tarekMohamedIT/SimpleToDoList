using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ToDoList.Core;
using ToDoList.Core.Persistence.Repositories.Concrete;
using ToDoList.Core.Services;
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
		private INoteViewModel _currentNoteViewModel;
		private IGenericRepository<BaseNote> _repo;
		private NotesService<BaseNote> _service;
		public Form1()
		{
			InitializeComponent();
			List<BaseNote> notesList;

			_repo = AppServicesResolver.Current.Resolve<IGenericRepository<BaseNote>>();

			_service = new NotesService<BaseNote>(_repo);
			notesList = _service.GetAll(null).ResultItem.ToList();

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
			var note = _service.GetAll(null).ResultItem.ToList()[listBox1.SelectedIndex];

			_currentNoteViewModel = NotesFactory.CreateViewModel(note);
			_currentNoteViewModel.InitControl(flowLayoutPanel1);

			label3.Text = $@"Date : {note.CreationDate:yyyy/MM/dd HH:mm:ss}";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var entity = _currentNoteViewModel.Entity as BaseNote;

			var result = entity.Id == 0 
				? _service.Add(entity)
				: _service.Update(entity);

			result = _service.SaveChanges();
			if (result.State != Utils.Results.ResultState.Success)
			{
				MessageBox.Show("Something has happened!");
				return;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			var addForm = new SelectNoteTypeForm();
			addForm.ShowDialog();

			var note = NotesFactory.CreateNoteModel(addForm.selectedItem);

			_service.Add(note);
			var result = _service.SaveChanges();
			if (result.State != Utils.Results.ResultState.Success)
			{
				MessageBox.Show("Something has happened!");
				return;
			}

			listBox1.Items.Add(note.Id.ToString("D5"));
			listBox1.SelectedIndex = note.Id;
		}

	}
}
