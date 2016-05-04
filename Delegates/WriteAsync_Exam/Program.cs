using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace WriteAsync_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        public async Task CreateAndWriteAsyncToFile()
        {
            using (FileStream stream = new FileStream("test.dat", FileMode.Create,
            FileAccess.Write, FileShare.None, 4096, true))
            {
                byte[] data = new byte[100000];
                new Random().NextBytes(data);
                await stream.WriteAsync(data, 0, data.Length);
            }
        }
        public async Task ReadAsyncHttpRequest()
        {
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync("http://www.microsoft.com");
        }

        public async Task ExecuteMultipleRequests()
        {
            HttpClient client = new HttpClient();
            string microsoft = await client.GetStringAsync("http://www.microsoft.com");
            string msdn = await client.GetStringAsync("http://msdn.microsoft.com");
            string blogs = await client.GetStringAsync("http://blogs.msdn.com/");

        }
        public async Task ExecuteMultipleRequestsInParallel()
        {
            HttpClient client = new HttpClient();
            Task microsoft = client.GetStringAsync("http://www.microsoft.com");
            Task msdn = client.GetStringAsync("http://msdn.microsoft.com");
            Task blogs = client.GetStringAsync("http://blogs.msdn.com/");
            await Task.WhenAll(microsoft, msdn, blogs);
        }
    }
}
