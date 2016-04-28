using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerable_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 5, 7, 9 };
            using (List<int>.Enumerator enumerator = numbers.GetEnumerator())
            {
                while (enumerator.MoveNext()) Console.WriteLine(enumerator.Current);
            }

            List<string> text = new List<string>() { "Ero", "Mero", "Kero" };

            using (List<string>.Enumerator enumerator1 = text.GetEnumerator())
            {
                while (enumerator1.MoveNext()) Console.WriteLine(enumerator1.Current);
            }
            Console.Read();
        }
    }
    class Person
    {
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
    class People : IEnumerable<Person>
    {
        public People(Person[] people)
        {
            this.people = people;
        }
        Person[] people;
        public IEnumerator<Person> GetEnumerator()
        {
            for (int index = 0; index < people.Length; index++)
            {
                yield return people[index];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
