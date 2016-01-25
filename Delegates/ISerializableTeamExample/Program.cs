using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ISerializableTeamExample
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Team : ISerializable
    {
        public string Name;
        public List<Person> Players;
        public virtual void GetObjectData(SerializationInfo si,
        StreamingContext sc)
        {
            si.AddValue("Name", Name);
            si.AddValue("PlayerData", Players.ToArray());
        }
        public Team() { }
        protected Team(SerializationInfo si, StreamingContext sc)
        {
            Name = si.GetString("Name");
            // Deserialize Players to an array to match our serialization:
            Person[] a = (Person[])si.GetValue("PlayerData", typeof(Person[]));
            // Construct a new List using this array:
            Players = new List<Person>(a);
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
