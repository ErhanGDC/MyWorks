using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicExample
{
    class Program
    {

        static void Main(string[] args)
        {
            int x, y;
            x = 10;
            y = 2;
            Console.WriteLine(Foo(x,y));
        }
        public static dynamic Foo(dynamic x,dynamic y)
        {
            return (x / y)*2; // Dynamic expression
        }

        static T Mean<T>(T x, T y)
        {
            dynamic result = ((dynamic)x + y) / 2;
            return (T)result;
        }
    }
    public class Person
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }

        // The Friends collection may contain Customers & Employees:
        public readonly IList<Person> friends = new Collection<Person>();
    }
    class Customer : Person { public decimal CreditLimit { get; set; } }
    class Employee : Person { public decimal Salary { get; set; } }
}
