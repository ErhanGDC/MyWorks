using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(0, 10);
            var parallelResult = numbers.AsParallel().AsOrdered()
            .Where(i => i % 2 == 0)
            .ToArray();
            foreach (int i in parallelResult)
                Console.WriteLine(i);

            Console.ReadLine();

            Console.WriteLine("-------------------------------------------------\n\n");

            var numberss = Enumerable.Range(0, 20);
            var parallelResultt = numberss.AsParallel().AsOrdered()
            .Where(i => i % 2 == 0).AsSequential();
            foreach (int i in parallelResultt.Take(5))
                Console.WriteLine(i);

            Console.ReadLine();

            Console.WriteLine("-------------------------------------------------\n\n");
            Console.WriteLine("-------------------------------------------------\n\n");

            var number = Enumerable.Range(0, 20);
            try
            {
                var parallelResul = number.AsParallel()
                .Where(i => IsEven(i));
                parallelResul.ForAll(e => Console.WriteLine(e));
            }
            catch (AggregateException e)
            {
                Console.WriteLine("There where {0} exceptions",
                e.InnerExceptions.Count);
            }
            Console.ReadLine();
        }
        public static bool IsEven(int i)
        {
            if (i % 10 == 0) throw new ArgumentException("i");
            return i % 2 == 0;
        }
    }

}