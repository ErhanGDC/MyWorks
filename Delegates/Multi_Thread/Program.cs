using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Multi_Thread
{
    class Program
    {
        //        Synchronizing resources
        //As you have seen, with the TPL support in .NET, it’s quite easy to create a multithreaded application.
        //But when you build real-world applications with multithreading, you run into problems
        //when you want to access the same data from multiple threads simultaneously. Listing
        //1-35 shows an example of what can go wrong.

        static void Main(string[] args)
        {
            int n = 0;

            

            object _lock = new object();

            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                    lock (_lock)
                        Interlocked.Increment(ref n);
                    //n++;
            });

            for (int i = 0; i < 1000000; i++)
                lock (_lock)
                    Interlocked.Decrement(ref n);
                    //n--;
            
            up.Wait();
            Console.WriteLine(n);
            Console.ReadLine();

            if (Interlocked.Exchange(ref n, 1) == 0) { }

            Console.WriteLine(n);
            Console.ReadLine();
        }
    }
}
