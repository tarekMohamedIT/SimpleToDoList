using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList.WindowsFormApp.Adapters
{
	public class TableLayoutAdapter<T> where T : Control
	{
		private TableLayoutPanel _table;
		private List<T> _itemsList;
		private int _currentRow = 0;
		private int _currentColumn = 0;

		public int ColumnsCount { get; set; } = 3;

		public TableLayoutAdapter(TableLayoutPanel table, bool isDemo = false)
		{
			_table = table;
			_itemsList = new List<T>();
			InitTable();

			if (isDemo) Demo();
		}

		private void InitTable()
		{
			_table.Controls.Clear();
			_table.AutoScroll = true;

			_table.ColumnCount = ColumnsCount;
			_table.RowCount = 0;

			_table.ColumnStyles.Clear();
			for (int i = 0; i < _table.ColumnCount; i++)
			{
				_table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
			}

			
		}

		public void Add(T item)
		{
			bool isNewRow = false;

			if (_currentColumn == ColumnsCount)
			{
				_currentColumn = 0;
				_currentRow++;

				isNewRow = true;
			}

			_table.Controls.Add(item, _currentColumn++, _currentRow);

			if (isNewRow || _table.RowCount == 0)
			{
				if (_table.RowCount == 0) _table.RowStyles.Clear();

				_table.RowCount++;
				_table.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
			}
		}

		public bool Update(T item, int row, int column)
		{
			if (row > _table.RowCount || column > _table.ColumnCount) return false;
			var child = _table.GetControlFromPosition(column, row);
			if (child == null) return false;

			_table.Controls.Remove(child);
			_table.Controls.Add(item, column, row);

			return true;
		}

		public bool Remove(int row, int column)
		{
			if (row > _table.RowCount || column > _table.ColumnCount) return false;
			var child = _table.GetControlFromPosition(column, row);
			if (child == null) return false;
			_table.Controls.Remove(child);

			return true;
		}

		public void Demo()
		{
			for (int i = 0; i < 20; i++)
			{
				Add(new Label()
				{
					Text = "test",
					BackColor = Color.Red,
					Margin = new Padding(3, 3, 3, 3),

					Dock = DockStyle.Fill,
					Height = 45
				} as T);
			}

			Update(new Label()
			{
				Text = "test",
				BackColor = Color.CadetBlue,
				Margin = new Padding(3, 3, 3, 3),

				Dock = DockStyle.Fill,
				Height = 45
			} as T, 2, 2);

			Remove(0, 0);
		}
	}
}
