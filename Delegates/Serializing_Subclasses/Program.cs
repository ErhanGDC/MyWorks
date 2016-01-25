using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;

namespace Serializing_Subclasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person { Name = "Stacey", Age = 30 };
            Student student = new Student { Name = "Stacey", Age = 30 };
            Teacher teacher = new Teacher { Name = "Stacey", Age = 30 };

            Person p2 = DeepClone(person); // OK
            Student s2 = (Student)DeepClone(student); // SerializationException
            Teacher t2 = (Teacher)DeepClone(teacher); // SerializationException

            Person p = new Person() { Name = "George", Age = 25 };
            IFormatter formatter = new BinaryFormatter();
            using (FileStream s = File.Create("serialized.bin"))
                formatter.Serialize(s, p);
        }

        static Person DeepClone(Person p)
        {
            var ds = new DataContractSerializer(typeof(Person));
            MemoryStream stream = new MemoryStream();
            ds.WriteObject(stream, p);
            stream.Position = 0; // Why ?
            return (Person)ds.ReadObject(stream);
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
    [DataContract]
    public class Student : Person { }
    [DataContract]
    public class Teacher : Person { }

}
