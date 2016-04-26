using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Chapter1_2
{
    class Program
    {
        public static ThreadLocal<int> _field =
        new ThreadLocal<int>(() =>
        {
            return Thread.CurrentThread.ManagedThreadId;
        });
        public static void Main()
        {
            var a = new Thread(() =>
            {
                for (int i = 0; i < _field.Value; i++)
                {
                    Console.WriteLine("Thread A: {0}", _field);
                    Thread.Sleep(1000);
                }
            });
            a.Name = "SALIH";
            a.Start();



            new Thread(() =>
            {
                for (int i = 0; i < _field.Value; i++)
                {
                    Console.WriteLine("Thread B: {0}", _field);
                    Thread.Sleep(1000);
                }
            }).Start();

            //Thread pools
            //When working directly with the Thread class, you create a new thread each time, and the thread dies when you’re finished with it. 
            //The creation of a thread, however, is something that costs some time and resources.
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine("Working on a thread from threadpool");
            });

            Console.Read();
        }
    }
}
