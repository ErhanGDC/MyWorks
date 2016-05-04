using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda_expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> addFunc = (x, y) => x + y;
            Console.WriteLine(addFunc(2, 3));

            //Func<int, int, int> mmultiply = (x, y) => x - y;
            //Console.WriteLine(multiply(15,5));

            Console.Read();
        }
    }
}
