using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using ToDoList.Core.Utilities;

namespace ToDoList.Core.Models
{
	public class CheckList : BaseNote
	{
		public List<ChecklistItem> Items { get; set; }

		public override void ReadXml(XmlReader reader)
		{
			bool wasEmpty = reader.IsEmptyElement;
			reader.Read();
			if (wasEmpty)
				return;

			Id = int.Parse(reader.ReadElementContentAsString());
			Title = reader.ReadElementString();

			reader.MoveToContent();
			this.Items = XmlGenericSerializer.Deserialize<List<ChecklistItem>>(reader);
			reader.ReadEndElement();

			//Read Closing Element
			reader.ReadEndElement();
		}

		public override void WriteXml(XmlWriter writer)
		{
			writer.WriteElementString("Id", Id.ToString());
			writer.WriteElementString("Title", Title);

			writer.WriteStartElement("Items");
			foreach (var checklistItem in Items)
			{
				writer.WriteStartElement("ChecklistItem");
				writer.WriteElementString("Text", checklistItem.Text);
				writer.WriteElementString("Checked", checklistItem.Checked.ToString());
				writer.WriteEndElement();
			}
			writer.WriteEndElement();
		}
	}
}