using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithStreams
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\temp\test.dat";
            using (FileStream fileStream = File.Create(path))
            {

                string myValue = "MyValue";
                byte[] data = Encoding.UTF8.GetBytes(myValue);
                fileStream.Write(data, 0, data.Length);
            }

            path = @"c:\temp\test.dat";
            using (StreamWriter streamWriter = File.CreateText(path))
            {
                string myValue = "MyValue";
                streamWriter.Write(myValue);
            }

            using (FileStream fileStream = File.OpenRead(path))
            {
                byte[] data = new byte[fileStream.Length];
                for (int index = 0; index < fileStream.Length; index++)
                {
                    data[index] = (byte)fileStream.ReadByte();
                }
                Console.WriteLine(Encoding.UTF8.GetString(data)); // Displays: MyValue
            }
        }
    }
}
