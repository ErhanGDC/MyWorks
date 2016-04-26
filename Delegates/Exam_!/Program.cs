using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;


using System.Net.Http;
using System.Threading;
namespace Exam_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //When you use the await keyword, the compiler generates code that will see whether your asynchronous operation is already finished.
            //If it is, your method just continues running synchronously.
            //If it’s not yet completed, the state machine will hook up a continuation method that should run when the Task completes.
            //Your method yields control to the calling thread, and this thread can be used to do other work.

            string result = DownloadContent().Result;
            Console.WriteLine(result);
            Console.ReadLine();
        }
        public static async Task<string> DownloadContent()
        {
            using (HttpClient client = new HttpClient())
            {
                // we use await keybord here because we have to wait until download finish. 
                string result = await client.GetStringAsync("http://www.microsoft.com");
                return result;
            }
        }
        public Task SleepAsyncA(int millisecondsTimeout)
        {
            return Task.Run(() => Thread.Sleep(millisecondsTimeout));
        }
        public Task SleepAsyncB(int millisecondsTimeout)
        {
            TaskCompletionSource<bool> tsc = null;
            var t = new Timer(delegate { tsc.TrySetResult(true); }, null, -1, -1);
            tsc = new TaskCompletionSource<bool>(t);
            t.Change(millisecondsTimeout, -1);
            return tsc.Task;
        }
    }
}
