using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumeration
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Erhan";

            //IEnumerator rator = s.GetEnumerator();
            //while (rator.MoveNext())
            //{
            //    char c = (char)rator.Current;
            //    Console.WriteLine(c+".");
            //}
            //

            foreach (char c in s)
                Console.WriteLine(c + ".");

            Console.Read();
        }
    }

    public interface IEnumerator 
    {
        bool MoveNext();
        object Current { get; }
        void Reset();
    }
    public interface IEnumerable
    {
        IEnumerable GetEnumerator();
    }
}
