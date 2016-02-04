using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = Task.Factory.StartNew(state => Greet("Hello"), "Greeting");
            Console.WriteLine(task.AsyncState); // Greeting
            task.Wait();

            var task1 = Task.Run(() => Console.Write("X"));
            var task2 = Task.Run(() => Console.Write("Y"));

            var t = Task.Factory.StartNew(() => Thread.Sleep(1000));
            t.ContinueWith(ant => Console.Write("X"));
            t.ContinueWith(ant => Console.Write("Y"));
        }
        static void Greet(string message) { Console.Write(message); }
    }
}
