using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace The_Parallel_Class
{
    class Program
    {
      //  public static void Invoke(params Action[] actions);
        static void Main(string[] args)
        {
            Parallel.Invoke(
            () => new WebClient().DownloadFile("http://www.linqpad.net", "lp.html"),
            () => new WebClient().DownloadFile("http://www.jaoo.dk", "jaoo.html"));
            Console.ReadLine();

            var data = new List<string>();
            Parallel.Invoke(
            () => data.Add(new WebClient().DownloadString("http://www.foo.com")),
            () => data.Add(new WebClient().DownloadString("http://www.far.com")));
        }
    }
}
