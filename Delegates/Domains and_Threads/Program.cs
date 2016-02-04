using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domains_and_Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create 20 domains and 20 threads.
            AppDomain[] domains = new AppDomain[20];
            Thread[] threads = new Thread[20];
            for (int i = 0; i < 20; i++)
            {
                domains[i] = AppDomain.CreateDomain("Client Login " + i);
                threads[i] = new Thread(LoginOtherDomain);
            }
            // Start all the threads, passing to each thread its app domain.
            for (int i = 0; i < 20; i++) threads[i].Start(domains[i]);
            // Wait for the threads to finish
            for (int i = 0; i < 20; i++) threads[i].Join();
            // Unload the app domains
            for (int i = 0; i < 20; i++) AppDomain.Unload(domains[i]);
            Console.ReadLine();
        }
        // Parameterized thread start - taking the domain on which to run.
        static void LoginOtherDomain(object domain)
        {
            ((AppDomain)domain).DoCallBack(Login);
        }
        static void Login()
        {
            Client.Login("Joe", "");
            Console.WriteLine("Logged in as: " + Client.CurrentUser + " on " +
            AppDomain.CurrentDomain.FriendlyName);
        }
    }
    class Client
    {
        // Here's a static field that would interfere with other client logins
        // if running in the same app domain.
        public static string CurrentUser = "";
        public static void Login(string name, string password)
        {
            if (CurrentUser.Length == 0) // If we're not already logged in...
            {
                // Sleep to simulate authentication...
                Thread.Sleep(500);
                CurrentUser = name; // Record that we're authenticated.
            }
        }
    }
}
