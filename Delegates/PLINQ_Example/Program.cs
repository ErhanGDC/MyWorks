using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace PLINQ_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Calculate prime numbers using a simple (unoptimized) algorithm.
            IEnumerable<int> Numbers = Enumerable.Range(3, 3000 - 3);
            var parallelQuery =
            from n in Numbers.AsParallel()
            where Enumerable.Range(2, (int)Math.Sqrt(n)).All(i => n % i > 0)
            select n;
            int[] primes = parallelQuery.ToArray();


            //            // I wrote these codes =)
            //           PLINQ is only for local collections: it doesn’t work with LINQ to SQL or Entity
            //Framework because in those cases the LINQ translates into SQL which then executes
            //on a database server. However, you can use PLINQ to perform additional local
            //querying on the result sets obtained from database queries.
            IEnumerable<int> mySequence = Enumerable.Range(0, 150);
            var result = mySequence.AsParallel().AsOrdered().WithExecutionMode(ParallelExecutionMode.ForceParallelism) // Wraps sequence in ParallelQuery<int>
            .Where(n => n > 100) // Outputs another ParallelQuery<int>
            .AsParallel() // Unnecessary - and inefficient!
            .Select(n => n * n);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
