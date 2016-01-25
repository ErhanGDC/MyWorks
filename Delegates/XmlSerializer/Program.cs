using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;

namespace XmlSerializerNS
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.Name = "Stacey"; p.Age = 30; p.HomeAddress.Street = "islambey Mah."; p.HomeAddress.PostCode = "34000";

            XmlSerializer xs = new XmlSerializer(typeof(Person));

            using (Stream s = File.Create("person.xml"))
                xs.Serialize(s, p);
            Person p2;
            using (Stream s = File.OpenRead("person.xml"))
                p2 = (Person)xs.Deserialize(s);
            Console.WriteLine(p2.Name + " " + p2.Age); // Stacey 30
        }
        public void SerializePerson(Person p, string path)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Person));
            using (Stream s = File.Create(path))
                xs.Serialize(s, p);
        }
    }
    public class Person
    {
        public string Name;
        public int Age;
        public Address HomeAddress = new USAddress();
        public List<Address> Addresses = new List<Address>(); //try this option too
    }
    public class Address { public string Street, PostCode; }
    public class USAddress : Address { }
    public class AUAddress : Address { }
    public class Student : Person { }
    public class Teacher : Person { }
}
