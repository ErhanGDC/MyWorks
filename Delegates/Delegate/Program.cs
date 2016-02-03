using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDynamic
{
    class Program
    {

        //I saw this first time.
       // public static string ToStringEx<T>(IEnumerable<IEnumerable<T>> sequence);

        delegate string StringToString(string s);
        static void Main(string[] args)
        {
            MethodInfo trimMethod = typeof(string).GetMethod("Trim", new Type[0]);
            var trim = (StringToString)Delegate.CreateDelegate(typeof(StringToString), trimMethod);

            for (int i = 0; i < 1000000; i++)
            {
                trim("Test");
            }

            //For example, consider the following C# code:
            int x = 6;
            int y = 7;
            x *= y;
            Console.WriteLine(x);
            Console.ReadLine();

            //For example, consider the following C# code:
            int xa = 5;
            while (x <= 10) Console.WriteLine (xa++);
            Console.ReadLine();

            // Great Example =)
            Type t = typeof(Arfitical);
            object o = Activator.CreateInstance(t);
            t.GetMethod("Method").Invoke(o, null);
            Console.ReadLine();
        }
    }
    public class Arfitical:abcd
    {
        public int age { get; set; }
        public Arfitical()
        {

        }
        public void Method (){Console.WriteLine("Hello World");
        }
        public override void Write() { }
        public override void Read() { }
    }
    public interface abc
    {
        void Write();
        void Read();
    }
    public abstract class abcd
    {
        abstract public void Write();
       abstract public void Read();
    }
}
