using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading
{
    class Program
    {
        static void Main(string[] args)
        {
            //if the x is non-null, give to me. Otherwise give to me defualt value
            int? x = null;
            int y = x ?? 5;
            Console.WriteLine(y.ToString());
            Note B = new Note(2);
            Note CSarp = B + 2;
            string s = "erhan";
            Console.WriteLine(s.IsCapitalized().ToString());
            Console.WriteLine();
            Console.ReadLine();
        }
    }
    public struct Note
    {
        int value;
        public Note(int semitoneFromA) { value = semitoneFromA; }
        public static Note operator +(Note x, int semitones)
        {
            return new Note(x.value + semitones);
        }
    }
    public static class StringHelper
    {
        public static bool IsCapitalized(this string s)
        {
           // if (string.IsNullOrEmpty(s)) { return false; }
            //else { return char.IsUpper(s[0]); }
            return char.IsUpper(s[0]);
        }
    }
}
