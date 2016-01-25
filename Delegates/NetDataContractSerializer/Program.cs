using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Xml;

namespace NetDataContractSerializerNS
{
    class Program
    {
        static void Main(string[] args)
        {
            var ns = new NetDataContractSerializer();
            // NetDataContractSerializer is otherwise the same to use
            // as DataContractSerializer.
            Person p = new Person { Name = "Stacey", Age = 30 };
            var ds = new DataContractSerializer(typeof(Person));
            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            using (XmlWriter w = XmlWriter.Create("person.xml", settings))
                ds.WriteObject(w, p);

            System.Diagnostics.Process.Start("person.xml");
        }
    }
    [DataContract]
    public class Person
    {
        [DataMember]
        public string Name;
        [DataMember]
        public int Age;
    }
}
