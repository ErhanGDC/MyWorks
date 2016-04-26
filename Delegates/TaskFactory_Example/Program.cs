using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskFactory_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<Int32[]> parent = Task.Run(() =>
            {
                var result = new Int32[3];
                TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously);

                tf.StartNew(() => result[0] = 0);
                tf.StartNew(() => result[1] = 1);
                tf.StartNew(() => result[2] = 2);
                return result;
            });

            var finalTask = parent.ContinueWith(parentTask =>
            {
                foreach (int item in parent.Result)
                {
                    Console.WriteLine(item);
                }
            });

            finalTask.Wait();
            Console.Read();
            Console.WriteLine("----------------------------------------------------------------------------------\n\n\n");

            Task[] tasks = new Task[3];
            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("1");
                return 1;
            });
            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("2");
                return 2;
            });
            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("3");
                return 3;
            }
            );
            Task.WaitAll(tasks);
            Console.Read();
            Console.ReadLine();

            Console.WriteLine("----------------------------------------------------------------------------------\n\n\n");
            Console.ReadLine();

            Task<int>[] taskss = new Task<int>[3];
            taskss[0] = Task.Run(() => { Thread.Sleep(2000); return 1; });
            taskss[1] = Task.Run(() => { Thread.Sleep(1000); return 2; });
            taskss[2] = Task.Run(() => { Thread.Sleep(3000); return 3; });
            while (tasks.Length > 0)
            {
                int i = Task.WaitAny(tasks);
                Task<int> completedTask = taskss[i];
                Console.WriteLine(completedTask.Result);
                var temp = taskss.ToList();
                temp.RemoveAt(i);
                taskss = temp.ToArray();
            }
            Console.Read();
            Console.ReadLine();
        }
    }
}
