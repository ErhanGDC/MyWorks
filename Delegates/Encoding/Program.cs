using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encoding
{
    class Program
    {
        static void Main(string[] args)
        {
            //foreach (Encoding info in Encoding.GetEncodings() )
            //{
            //    Console.WriteLine(info.Name);
            //}
            //System.IO.File.WriteAllText("data.txt","Testing...",Encoding.Unicode);

            Console.WriteLine(new TimeSpan(2,30,0));

            Console.WriteLine(TimeSpan.FromHours(2.5));

            Console.Read();
        }
    }
}
