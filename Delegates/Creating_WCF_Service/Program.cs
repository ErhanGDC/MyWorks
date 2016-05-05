using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace Creating_WCF_Service
{
    class Program
    {
        static void Main(string[] args)
        {
            string xml = @"<?xml version=””1.0”” encoding=""utf-8"" ?>
<people>
<person firstname=""john"" lastname=""doe"">
<contactdetails>
<emailaddress>john@unknown.com</emailaddress>
</contactdetails>
</person>
<person firstname=""jane"" lastname=""doe"">
<contactdetails>
<emailaddress>jane@unknown.com</emailaddress>
<phonenumber>001122334455</phonenumber>
</contactdetails>
</person>
</people>";

            using (StringReader stringReader = new StringReader(xml))
            {
                using (XmlReader xmlReader = XmlReader.Create(stringReader,
                new XmlReaderSettings() { IgnoreWhitespace = true }))
                {
                    xmlReader.MoveToContent();
                    xmlReader.ReadStartElement("People");
                    string firstName = xmlReader.GetAttribute("firstName");
                    string lastName = xmlReader.GetAttribute("lastName");
                    Console.WriteLine("Person: {0} {1}", firstName, lastName);
                    xmlReader.ReadStartElement("Person");
                    Console.WriteLine("ContactDetails");
                    xmlReader.ReadStartElement("ContactDetails");
                    string emailAddress = xmlReader.ReadString();
                    Console.WriteLine("Email address: {0}", emailAddress);
                }
            }
        }
    }
}
