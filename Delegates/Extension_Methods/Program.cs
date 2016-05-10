using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 2;
            Console.WriteLine(x.Multiply(3)); // Displays 6
        }
    }
    public static class IntExtensions
    {
        public static int Multiply(this int x, int y)
        {
            return x * y;
        }
    }
}
