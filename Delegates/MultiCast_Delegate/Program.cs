using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCast_Delegate
{
    public delegate void ProgressReporter(int percentComplate);
    public class Util
    {
        public static void HardWork(ProgressReporter p)
        {
            for (int i = 0; i < 10; i++)
            {
                p(i * 10);
                System.Threading.Thread.Sleep(2000);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ProgressReporter p = WriteProgressToConsole;
            p += WriteProgressToFile;
            Util.HardWork(p);
            Console.ReadLine();
        }

        static void WriteProgressToConsole(int percentComplate)
        {
            Console.WriteLine(percentComplate);
        }

        static void WriteProgressToFile(int percentComplate)
        {
            System.IO.File.WriteAllText("progress.txt",percentComplate.ToString());
        }
    }
}



