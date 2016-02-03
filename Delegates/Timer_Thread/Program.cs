using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Timer_Thread
{
    class Program
    {
        static void Main(string[] args)
        {
            //Timer tmr = new Timer(); // Doesn't require any args
            //tmr.Interval = 500;
            //tmr.Elapsed += tmr_Elapsed; // Uses an event instead of a delegate
            //tmr.Start(); // Start the timer
            //Console.ReadLine();
            //tmr.Stop(); // Stop the timer
            //Console.ReadLine();
            //tmr.Start(); // Restart the timer
            //Console.ReadLine();
            //tmr.Dispose(); // Permanently stop the timer
        }
        public void TimerMethod()
        {
            //new Thread(delegate()
            //{
            //    while (enabled)
            //    {
            //        DoSomeAction();
            //        Thread.Sleep(TimeSpan.FromHours(24));
            //    }
            //}).Start();       

        }
        static void tmr_Elapsed(object sender, EventArgs e)
        {
            Console.WriteLine("Tick");
        }

        private void DoSomeAction()
        {
            Console.WriteLine("Timer !");
        }
    }
}
