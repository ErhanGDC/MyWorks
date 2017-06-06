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


            OrderLine ol1 = new OrderLine() { Amount = 10, Product = new Product() { Description = "AMK1", Price = 1 } };
            OrderLine ol2 = new OrderLine() { Amount = 20, Product = new Product() { Description = "AMK2", Price = 2 } };
            OrderLine ol3 = new OrderLine() { Amount = 30, Product = new Product() { Description = "AMK3", Price = 3 } };
            OrderLine ol4 = new OrderLine() { Amount = 40, Product = new Product() { Description = "AMK4", Price = 4 } };
            OrderLine ol5 = new OrderLine() { Amount = 50, Product = new Product() { Description = "AMK5", Price = 5 } };
            OrderLine ol6 = new OrderLine() { Amount = 60, Product = new Product() { Description = "AMK6", Price = 6 } };
            OrderLine ol7 = new OrderLine() { Amount = 70, Product = new Product() { Description = "AMK7", Price = 7 } };
            OrderLine ol8 = new OrderLine() { Amount = 80, Product = new Product() { Description = "AMK8", Price = 8 } };
            OrderLine ol9 = new OrderLine() { Amount = 90, Product = new Product() { Description = "AMK9", Price = 9 } };

            List<OrderLine> ListOrderLines = new List<OrderLine>();
            ListOrderLines.Add(ol1);
            ListOrderLines.Add(ol2);
            ListOrderLines.Add(ol3);
            ListOrderLines.Add(ol4);
            ListOrderLines.Add(ol5);
            ListOrderLines.Add(ol6);
            ListOrderLines.Add(ol7);
            ListOrderLines.Add(ol8);
            ListOrderLines.Add(ol9);

            var averageNumberOfOrderLine = ListOrderLines.Average(x => x.Product.Price);
            var BigResult = from o in ListOrderLines
                            from l in ListOrderLines
                            group l by l.Product into p
                            select new
                            {
                                Product = p.Key,
                                Amount = p.Sum(x => x.Amount)
                            };

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
