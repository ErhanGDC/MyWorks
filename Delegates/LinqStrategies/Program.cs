using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace LinqStrategies
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Mai", "Joe", "Jesse", "Kevin", "Anderson", "Ronaldo" };

            //IEnumerable<string> query = names
            //    .Select(n => n.Replace("a", "").Replace("e", "").Replace("i", "").Replace("o", "").Replace("u", ""))
            //    .Where(n => n.Length > 2)
            //    .OrderBy(n => n);

            IEnumerable<tempProjectionItem> temp = from n in names
                                       select new tempProjectionItem
                                       {
                                           Orginal = n,
                                           VowelLess = n.Replace("a", "").Replace("e", "").Replace("i", "").Replace("o", "").Replace("u", "")
                                       };
            

            foreach (var item in temp)
            {
                Console.WriteLine(item.Orginal);
            }
            Console.ReadLine();
        }
    }
    public class tempProjectionItem
    {
        public string Orginal;
        public string VowelLess;
    }
}
