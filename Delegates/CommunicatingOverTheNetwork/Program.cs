using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CommunicatingOverTheNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            WebRequest request = WebRequest.Create("http://www.microsoft.com");
            WebResponse response = request.GetResponse();
            StreamReader responseStream = new StreamReader(response.GetResponseStream());
            string responseText = responseStream.ReadToEnd();
            Console.WriteLine(responseText); // Displays the HTML of the website
            response.Close();
        }
    }
}
