using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public delegate int Transformer(int x);
    class Util
    {
        // we are sending the squera method to Transform Metdod as following.  Transformer is also a Squera. Because The signature is same.
        // the "t" is represent the Squera method
        public static void Transform(int[] values, Transformer t)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = t(values[i]);
            }
        }
    }
    class Program
    {      
        static void Main(string[] args)
        {
            int[] values = {1,2,3 };
            
            // we are sending the squera method to Transform Metdod as following.  Transformer is also a Squera. Because The signature is same.
            Util.Transform(values, Squera);

            foreach (int i in values)
            {
                Console.WriteLine(i + " ");
            }
            Console.ReadLine();
        }

        static int Squera(int x) { return x * x; }
    }
}
