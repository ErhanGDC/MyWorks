using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exam_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.For(0, 10, i => { Console.WriteLine("For"+i); Thread.Sleep(1000); });

            var numbers = Enumerable.Range(0, 10);

            Parallel.ForEach(numbers, i => { Console.WriteLine("ForEach" + i); Thread.Sleep(1000); });
            Console.WriteLine("-------------------------------------------");
            Console.ReadLine();

            ParallelLoopResult result = Parallel.For(0, 1000, (int i, ParallelLoopState loopState) => 
            {
                if (i==500)
                {
                    Console.WriteLine("Breaking Loop =) "+i);
                    loopState.Break();
                }
                return;
            });

            Console.ReadLine();
        }
    }
}
