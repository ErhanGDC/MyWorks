using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<Int32[]> parent = Task.Run(() =>
            {
                var result = new Int32[3];
                new Task(() => result[0] = 0, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => result[1] = 1, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => result[2] = 2, TaskCreationOptions.AttachedToParent).Start();
                return result;
            });

            var finalTask = parent.ContinueWith(parentTask =>
            {
                foreach (int item in parentTask.Result)
                {
                    Console.WriteLine(item);
                }
            });

            finalTask.Wait();
            Console.Read();
        }
    }
}
