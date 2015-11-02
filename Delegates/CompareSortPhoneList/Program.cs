using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareSortPhoneList
{
    class Program
    {
        static void Main(string[] args)
        {
            var dic = new SortedDictionary<string, string>(new SurnameComparer());
            dic.Add("MacPhail","second");
            dic.Add("MacWilliam","third");
            dic.Add("McDonald", "first");
            foreach (string s in dic.Values)
                Console.WriteLine(s + " " );
            Console.ReadLine();
        }
    }
    class SurnameComparer :Comparer<string>
    {
        string Normalize(string s) 
        {
            s = s.Trim().ToUpper();
            if (s.StartsWith("MC")) s = "MAC" + s.Substring(2);
            return s;
        }
        public override int Compare(string x, string y)
        {
            return Normalize(x).CompareTo(Normalize(y));
        }
    }
}
