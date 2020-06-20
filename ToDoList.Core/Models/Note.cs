using System;
using System.Globalization;
using System.Xml;

namespace ToDoList.Core.Models
{
	public class Note : BaseNote
	{
		public string Text { get; set; }

		public override void ReadXml(XmlReader reader)
		{
			Id = int.Parse(reader.ReadElementContentAsString());
			Title = reader.ReadElementContentAsString();
			Text = reader.ReadElementContentAsString();
			CreationDate = DateTime.Parse(reader.ReadElementContentAsString());
		}

		public override void WriteXml(XmlWriter writer)
		{
			writer.WriteElementString("Id", Id.ToString());
			writer.WriteElementString("Title", Title);
			writer.WriteElementString("Text", Text);
			writer.WriteElementString("CreationDate", CreationDate.ToString(CultureInfo.CurrentCulture));
		}
	}
}
