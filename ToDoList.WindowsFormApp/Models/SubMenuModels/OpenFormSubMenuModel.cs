using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoList.WindowsFormApp.Contexts;
using ToDoList.WindowsFormApp.Factories;

namespace ToDoList.WindowsFormApp.Models.SubMenuModels
{
	public class OpenFormSubMenuModel : SubMenuModel
	{

		public override List<SubMenuModel> SubMenuItems
		{
			get => null;
			set { }
		}

		public override EventHandler OnClick
		{
			get
			{
				return (sender, args) =>
				{
					var form = _formFactory.Invoke();
					FormsContext.Instance.CurrentActiveForm?.Close();
					FormsContext.Instance.CurrentActiveForm = form;

					if (form == null) return;

					form.TopLevel = false;
					form.FormBorderStyle = FormBorderStyle.None;
					form.Dock = DockStyle.Fill;
					_parent.Controls.Add(form);
					_parent.Tag = form;
					form.BringToFront();
					form.Show();
				};
			}
			set
			{

			}
		}

		private Func<Form> _formFactory;
		private Panel _parent;

		public OpenFormSubMenuModel(Func<Form> formFactory, Panel parent)
		{
			_formFactory = formFactory;
			_parent = parent;
		}


	}
}
