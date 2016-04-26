using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Chapter1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            bool stopped = false;


            Thread t1 = new Thread(new ThreadStart(() => {
                while (!stopped)
                {
                    Console.WriteLine("Running...");
                    Thread.Sleep(1000);
                }
            }));

            t1.Start();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            stopped = true;
            t1.Join();

            Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));
            t.IsBackground = false;
            t.Start(5);
            t.Join();
            Console.Read();
        }

        public static void ThreadMethod(object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(1000);
            }
        }
    }
}
