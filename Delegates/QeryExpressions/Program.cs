using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace QeryExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Mai", "Joe", "Jesse", "Kevin", "Anderson", "Ronaldo" };

            int matched=(from n in names 
                          where n.Contains("a") select n).Count();

            Console.WriteLine(matched.ToString());

            string first = (from n in names
                            orderby n
                            select n).First();

            Console.WriteLine(first);

            Action a = () => Console.WriteLine("Foo");
            Console.ReadLine();
           
            a();

            Console.WriteLine("-----------------------------------------------------------------------------------");
            IEnumerable<int> query = new int[] { 2, 12, 5 }.Where(n => n < 10)
                                                     .OrderBy(n => n)
                                                     .Select(n => n * 10);
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
                
            Console.ReadLine();
        }
    }
}
