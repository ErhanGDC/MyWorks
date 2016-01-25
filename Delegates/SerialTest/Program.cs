using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;

namespace SerialTest
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public string Name;
        [DataMember]
        public int Age;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person { Name = "Stacey", Age = 30 };
            var ds = new DataContractSerializer(typeof(Person));

            using (Stream s = File.Create("person.xml"))
                ds.WriteObject(s, p); // Serialize
            Person p2;
            using (Stream s = File.OpenRead("person.xml"))
                p2 = (Person)ds.ReadObject(s); // Deserialize
            Console.WriteLine(p2.Name + " " + p2.Age); // Stacey 30

            //My example
            Person MyP = new Person { Name = "Erhan", Age = 24 };
            var myDs = new DataContractSerializer(typeof(Person));

            //using (Stream mys = File.Create("MyPerson.xml"))
            //    myDs.WriteObject(MyP, mys); //Serialize işlemi yapıldı WriteObject

            //Person p3;
            //using (Stream myss = File.OpenRead("MyPerson.xml"))
            //    myDs.ReadObject(myss);

            //Console.WriteLine(p3.Name,p3.Age);

        }
    }
}
