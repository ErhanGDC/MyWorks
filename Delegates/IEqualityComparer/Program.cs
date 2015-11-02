using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEqualityComparer
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer c1 = new Customer("Bloggs", "Joe");
            Customer c2 = new Customer("Bloggs", "Joe");

            Console.WriteLine(c1==c2);
            Console.WriteLine(c1.Equals(c2));

            Console.ReadLine();
            Console.WriteLine("-----------------------------------------\n");
            var d = new Dictionary<Customer, string>();
            d[c1] = "Joe";
            Console.WriteLine(d.ContainsKey(c2));
            Console.WriteLine("-----------------------------------------\n");

            var eqComparer = new LastFirstEqComparer();
            var d1 = new Dictionary<Customer, string>(eqComparer);
            d1[c1] = "Joe";
            Console.WriteLine(d.ContainsKey(c2));

            Console.ReadLine();


        }
    }

    public class Customer
    {
        public string LastName;
        public string FirstName;

        public Customer(string lastname, string firstname)
        {
            LastName = lastname;
            FirstName = firstname;
        }
    }

    public class LastFirstEqComparer : EqualityComparer<Customer>
    {
        public override bool Equals(Customer x, Customer y)
        {
            return x.LastName == y.LastName && x.FirstName == y.FirstName;
        }
        public override int GetHashCode(Customer obj)
        {
            return (obj.LastName + ";" + obj.FirstName).GetHashCode();
        }
    }
}
