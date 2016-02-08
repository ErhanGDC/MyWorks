using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> AllNumbers = new List<int>();
            int[] Numbers=new int[101];

           
            for (int i = 0; i < Numbers.Length; i++)
            {
                Numbers[i] += i;
            }
            
            //Fill and Drain =)
            for (int j = 0; j < Numbers.Length; j++)
            {
                AllNumbers.Add(j);
            }

            for (int i = 1; i < AllNumbers.Capacity; i++)
            {
               // if (AllNumbers[i] % 1 == 1)
               // {
                    Console.WriteLine(i);
               // }
            }

            Console.ReadLine();

        }
    }
}
