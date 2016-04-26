using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Que
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcurrentStack<int> stack = new ConcurrentStack<int>();
            stack.Push(67);

            int result;
            if (stack.TryPop(out result))
                Console.WriteLine("Popped: {0}", result);
            stack.PushRange(new int[] { 1, 2, 3 });
            int[] values = new int[2];
            stack.TryPopRange(values);
            foreach (int i in values)
                Console.WriteLine(i);

            Console.WriteLine("\n\n----------------------------------------------------------------------\n\n");
            Console.ReadLine();

            var dict = new ConcurrentDictionary<string, int>();
            if (dict.TryAdd("ERHAN",26))
            {
                Console.WriteLine("Added");
            }
            if (dict.TryUpdate("ERHAN", 30, 26))
            {
                Console.WriteLine("26 updated to 30");
            }

            dict["ERHAN"] = 32; // Overwrite unconditionally

            Console.WriteLine("----------------------------------------------------------------------");
            Console.ReadLine();

            int r = dict.AddOrUpdate("ERHAN", 35, (S, I) => I * 2);
            Console.WriteLine(r);
            int r2 = dict.GetOrAdd("ERHAN", 37);

            Console.WriteLine("----------------------------------------------------------------------");
            Console.ReadLine();

        }
    }
}
