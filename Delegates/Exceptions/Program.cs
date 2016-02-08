using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"ForLoop.txt");
            try
            {
                ///reader.File.OpenText("For Loop.txt");
                if (reader.EndOfStream)
                {
                    return;
                }
                Console.WriteLine(reader.ReadToEnd());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally { if (reader != null) reader.Dispose(); }
            Console.ReadLine();
        }
    }
}
