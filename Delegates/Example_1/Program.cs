using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1
{
    class Program
    {
        public delegate int Calculate(int x, int y);
        public static int Add(int x, int y) { return x + y; }
        public static int Mutiply(int x, int y) { return x * y; }
        static void Main(string[] args)
        {
            Calculate calc = (x, y) => x + y;
            Console.WriteLine(calc(3, 4)); // Displays 7
            calc = (x, y) => x * y;
            Console.WriteLine(calc(3, 4)); // Displays 12
            
            // you can create your calculate without write a new method :) Thanks a lot Lambda expression :)
            calc = (x, y) => x / y;
            Console.WriteLine(calc(10,2));

            Console.WriteLine("----------------------------------------------\n");

            calc = (x, y) => { Console.WriteLine("Abstract : {0}", x - y); return x - y; };
            Console.WriteLine(calc(25, 5));

            Console.ReadLine();

            Console.WriteLine("----------------------------------------------\n");

            Action<int, int> calc1 = (x, y) => { Console.WriteLine(x - y);};
            calc1(50, 25);

            Console.ReadLine();
        }
    }
}
