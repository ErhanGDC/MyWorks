using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Islem isc=new Islem(10, 5);
           
            Console.WriteLine( isc.Bol().ToString());
            Console.ReadLine();
        }
    }
    public class Islem
    {
        public Islem() { }
        public Islem(int sayi1, int sayi2)
        {
            this.Sayi1 = sayi1;
            this.Sayi2 = sayi2;
        }

        public int Sayi1 { get; set; }
        public int Sayi2 { get; set; }

        public int Carp()
        {
            return this.Sayi1 * this.Sayi2;
        }
        public int Bol()
        {
            return this.Sayi1 / this.Sayi2;
        }
    }
}
