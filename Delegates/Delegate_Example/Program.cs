using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Example
{
    public delegate int Calculate(int x, int y);
    public delegate void Del();
    public delegate TextWriter CovarianceDel();
    class Program
    {
        public static int Add(int x, int y) { return x + y; }
        public static int Mutiply(int x, int y) { return x * y; }
        static void Main(string[] args)
        {
            Calculate cal = Add;
            Console.WriteLine(cal(5, 5));

            Calculate cal1 = Mutiply;
            Console.WriteLine(cal1(8, 8));

            Console.ReadLine();

            Del d= MethodOne;
            d += MethodTwo;

            d();

            int invocationCount=d.GetInvocationList().GetLength(0);
            Console.WriteLine(invocationCount);

            CovarianceDel Cov= null;
            Cov = MethodStream;
            Cov = MethodString;

            Console.ReadLine();
        }
        static public void MethodOne()
        {
            Console.WriteLine("MethodOne");
        }
        static public void MethodTwo()
        {
            Console.WriteLine("MethodTwo");
        }

        static public StreamWriter MethodStream() { return null; }
        static public StringWriter MethodString() { return null; }
    }
}
