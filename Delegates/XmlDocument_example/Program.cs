using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlDocument_example
{
    class Program
    {
        static void Main(string[] args)
        {
            StringWriter stream = new StringWriter();
            using (XmlWriter writer = XmlWriter.Create(
            stream,
            new XmlWriterSettings() { Indent = true }))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("People");
                writer.WriteStartElement("Person");
                writer.WriteAttributeString("firstName", "John");
                writer.WriteAttributeString("lastName", "Doe");
                writer.WriteStartElement("ContactDetails");
                writer.WriteElementString("EmailAddress", "john@unknown.com");
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.Flush();
            }
            Console.WriteLine(stream.ToString());


            //We add the produced xml data here
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(stream.ToString());
            XmlNodeList nodes = doc.GetElementsByTagName("Person");
            // Output the names of the people in the document
            foreach (XmlNode node in nodes)
            {
                string firstName = node.Attributes["firstName"].Value;
                string lastName = node.Attributes["lastName"].Value;
                Console.WriteLine("Name: {0} {1}", firstName, lastName);
            }
            // Start creating a new node
            XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "Person", "");
            XmlAttribute firstNameAttribute = doc.CreateAttribute("firstName");
            firstNameAttribute.Value = "Foo";
            XmlAttribute lastNameAttribute = doc.CreateAttribute("lastName");
            lastNameAttribute.Value = "Bar";
            newNode.Attributes.Append(firstNameAttribute);
            newNode.Attributes.Append(lastNameAttribute);
            doc.DocumentElement.AppendChild(newNode);
            Console.WriteLine("Modified xml...");
            doc.Save(Console.Out);
        }
    }
}
