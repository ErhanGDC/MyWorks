using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Anonymous_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new
            {
                FirstName = "John",
                LastName = "Doe"
            };
            Console.WriteLine(person.GetType().Name); // Displays “<>f__AnonymousType0`2”

            int[] data = { 1, 2, 5, 8, 11 };
            var result = from d in data
                         where d % 2 == 0
                         select d;
            foreach (int i in result)
            {
                Console.WriteLine(i);
            }
            // Displays 2 8

            var result1 = data.Where(d => d % 2 == 0);


            int[] data2 = { 1, 2, 5, 8, 11 };
            var result2 = from d in data
                          select d;
            Console.WriteLine(string.Join(", ", result2)); // Displays 1, 2, 5, 8, 11

            int[] data3 = { 1, 2, 5, 8, 11 };
            var result3 = from d in data3
                          where d > 5
                          orderby d descending
                          select d;
            Console.WriteLine(string.Join(", ", result3)); // Displays 11, 8



            int[] data11 = { 1, 2, 5 };
            int[] data22 = { 2, 4, 6 };
            var result4 = from d11 in data11
                          from d22 in data22
                          select d11 * d22;
            Console.WriteLine(string.Join(", ", result4)); // Displays 2, 4, 6, 4, 8, 12, 10, 20, 30


            //var averageNumberOfOrderLines = orders.Average(o => o.OrderLines.Count);
            //var result1 = from o in orders
            //             from l in o.OrderLines
            //             group l by l.Product into p
            //             select new
            //             {
            //                 Product = p.Key,
            //                 Amount = p.Sum(x => x.Amount)
            //             };
        }
    }
    public static class Person
    {
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
    }
    public class Product
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
    public class OrderLine
    {
        public int Amount { get; set; }
        public Product Product { get; set; }
    }
    public class Order
    {
        public List<OrderLine> OrderLines { get; set; }
    }
}
