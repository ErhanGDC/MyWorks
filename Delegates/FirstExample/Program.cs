using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace FirstExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Tom", "Dick", "Harry","Mary","Jay" };
            //IEnumerable<string> filteredNames = System.Linq.Enumerable.Where(names, n => n.Length >= 4);
            //var filteredNames=names.Where(n=> n.Length>3);
            //IEnumerable<string> filteredNames = names.Where(n => n.Contains("a"));
            //IEnumerable<string> filteredNames = from n in names
            //                                    where n.Contains("a")
            //                                    select n;
            //IEnumerable<string> filteredNames = names.Where(n => n.Contains("a"))
            //                                   .OrderBy(n => n.Length)
            //                                   .Select(n => n.ToUpper());

            IEnumerable<string> query = Enumerable.Select(
                Enumerable.OrderBy(
                Enumerable.Where(
                names, n => n.Contains("a")
                ), n => n.Length), n => n.ToUpper());



            foreach(string n in query)
                Console.WriteLine(n);

            Console.ReadLine();
        }
    }                             
    }