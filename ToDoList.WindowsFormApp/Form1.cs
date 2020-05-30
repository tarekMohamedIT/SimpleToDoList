using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoList.Core.Models;
using ToDoList.Core.Persistence.DataProviders;
using ToDoList.Core.Persistence.Repositories;
using ToDoList.Core.Persistence.Repositories.Concrete;

namespace ToDoList.WindowsFormApp
{
	public partial class Form1 : Form
	{
		private IRepository<Note> _notesRepository;
		private IProvider<Note> _noteProvider;

		public Form1()
		{
			InitializeComponent();
			_noteProvider = new JsonDataProvider<Note>("test.json");
			_notesRepository = new BaseMemoryRepository<Note>(_noteProvider);

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

			textBox1.Text = note.Name;
			textBox2.Text = note.Text;
			label3.Text = $@"Date : {note.CreationDate:yyyy/MM/dd HH:mm:ss}";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var note = _notesRepository.Table.ToList()[listBox1.SelectedIndex];
			note.Name = textBox1.Text;
			note.Text = textBox2.Text;

			_notesRepository.Update(note);
			_noteProvider.Save();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			var note = new Note()
			{
				Id = listBox1.SelectedIndex + 1,
				CreationDate = DateTime.Now
			};

			_notesRepository.Insert(note);
			listBox1.Items.Add(note.CreationDate.ToString("yyyy/MM/dd HH:mm:ss"));
			listBox1.SelectedIndex = note.Id;
		}
	}
}
