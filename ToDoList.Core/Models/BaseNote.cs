using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ToDoList.Core.Models
{
	[Serializable]
	public abstract class BaseNote : IEntity
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public DateTime CreationDate { get; set; }

		public XmlSchema GetSchema()
		{
			return null;
		}

		public abstract void ReadXml(XmlReader reader);
		public abstract void WriteXml(XmlWriter writer);
	}
}