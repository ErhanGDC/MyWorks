using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bool_Expression
{
    class Program
    {
        static void Main(string[] args)
        {
            // Starved 
           
            int value = 42;
           bool result = (0 < value) && (value < 100);
           Console.WriteLine(result);

            bool a = true;
            bool b = false;

            Console.WriteLine("Results : {0}, {1}, {2} ",a ^ a,a ^ b,b ^ b); 

            //The following code is perfectly legal, but on first sight it’s hard to see what the code really does:
            if (a ^ b) if (a ^ a) F(); else G();

            Console.ReadLine();
        }

        private static void F()
        {
            Console.WriteLine("function F");
        }

        private static void G()
        {
            Console.WriteLine("function G");
        }
        public void OrShortCircuit()
        {
            bool x = true;
            bool result = x || GetY();
        }
        private bool GetY()
        {
            Console.WriteLine("This method doesn’t get called");
            return true;
        }
    }
}
