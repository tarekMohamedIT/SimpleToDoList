using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList.WindowsFormApp.Forms.Popups
{
	public partial class SelectNoteTypeForm : Form
	{
		public string selectedItem { get; private set; }

		public SelectNoteTypeForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			selectedItem = comboBox1.Text;
			Close();
		}
	}
}
