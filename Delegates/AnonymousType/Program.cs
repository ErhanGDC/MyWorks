using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;

namespace AnonymousType
{
    class Program
    {
        static void Main(string[] args)
        {
            // we can create method at runtime..
            dynamic d = new Duck();
            d.Quack();
            d.Waddle();

            object o = new System.Text.StringBuilder();
            dynamic e = o;

            dynamic a = 1;
            int min = a + 1;
            Console.WriteLine(min);

            a = ".a.s";
            string[] parsed = a.Split('.');

            Console.WriteLine(parsed[1].ToString());

            e.Append("hello Babo");
            Console.WriteLine(o);
            Console.ReadLine();
        }
    }
    public class Duck : DynamicObject
    {
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            Console.WriteLine(binder.Name+" method was called");
            result = null;
            return true;
        }
    }
}
