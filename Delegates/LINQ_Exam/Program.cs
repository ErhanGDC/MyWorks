using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, IEnumerable<Tuple<Type, int>>> data = new Dictionary<string, IEnumerable<Tuple<Type, int>>>();
            var implicitData = new Dictionary<string, IEnumerable<Tuple<Type, int>>>();

            // Create and initialize a new object
            Person p = new Person();
            p.FirstName = "John";
            p.LastName = "Doe";

            var people = new List<Person>
            {
                new Person(){FirstName = "Erhan",LastName ="Gidici"},
                new Person(){FirstName = "Ero",LastName ="Gid"},
                new Person(){FirstName = "Era",LastName ="Gidi"}
            };


            //Lambda expressions To understand what a lambda expression is, 
            //it’s important that you first know what an anonymous method is.
            //Anonymous methods were introduced in C# 2.0 to enable you to create a method inline in some code,
            //assign it to a variable, and pass it around.
            //Listing 4-51 shows how to create an anonymous method.
            Func<int, int> myDelegate =delegate(int x)
           {
                return x * 2;
            };
            Console.WriteLine(myDelegate(21)); // Displays 42

            //Lamda Version
            Func<int, int> myDelegate1 = x => x * 2;
            Console.WriteLine(myDelegate1(21)); // Displays 42
        }
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
