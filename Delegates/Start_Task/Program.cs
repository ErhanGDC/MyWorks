using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t = Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("*** " + i);
                }
            });

            t.Wait();

            Task<int> t1 = Task.Run(() =>
            {
                return 42;
            }).ContinueWith((i) => 
            { return i.Result * 2; }
            );

            Console.WriteLine(t1.Result); 
            Console.Read();

            Console.WriteLine("------------------------------");

            Task t3 = Task.Run(() => {
                return 67;
            });

            t3.ContinueWith((i) => { Console.WriteLine("Canceled "); },TaskContinuationOptions.OnlyOnCanceled);

            t3.ContinueWith((i) => {
                Console.WriteLine("Faulted");
            },TaskContinuationOptions.OnlyOnFaulted);

            var completeTask = t.ContinueWith((i) => { Console.WriteLine("Completed"); }, TaskContinuationOptions.NotOnRanToCompletion);

            completeTask.Wait();
            Console.Read();
        }
    }
}
