using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VisitorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var cust = new Customer { Firstname = "Erhan", LastName = "Gidici", CreditLimit = 5000 };
            cust.friends.Add(new Employee {Firstname="Sue", LastName="Kil", Salary=1500 });
            Console.WriteLine(new ToXElementPersonVisitor().DynamicVisit(cust));
            Console.ReadLine();
        }
    }
    public class Person
    {
        public string Firstname { get; set; }

        // The Friends collection may contain Customers & Employees:
        public string LastName { get; set; }
        public readonly IList<Person> friends = new Collection<Person>();
    }
    class Customer : Person { public decimal CreditLimit { get; set; } }
    class Employee : Person { public decimal Salary { get; set; } }

    // Visitor Pattern
    class ToXElementPersonVisitor
    {
        public XElement DynamicVisit(Person p)
        {
            return Visit((dynamic)p);
        }
        XElement Visit(Person p)
        {
            return new XElement("Person",
            new XAttribute("Type", p.GetType().Name),
            new XElement("FirstName", p.Firstname),
            new XElement("LastName", p.LastName),
            p.friends.Select(f => DynamicVisit(f))
            );
        }
        XElement Visit(Customer c) // Specialized logic for customers
        {
            XElement xe = Visit((Person)c); // Call "base" method
            xe.Add(new XElement("CreditLimit", c.CreditLimit));
            return xe;
        }
        XElement Visit(Employee e) // Specialized logic for employees
        {
            XElement xe = Visit((Person)e); // Call "base" method
            xe.Add(new XElement("Salary", e.Salary));
            return xe;
        }
    }
    abstract class PersonVisitor<T>
    {
        public T DynamicVisit(Person p) { return Visit((dynamic)p); }
        protected abstract T Visit(Person p);
        protected virtual T Visit(Customer c) { return Visit((Person)c); }
        protected virtual T Visit(Employee e) { return Visit((Person)e); }
    }

}
