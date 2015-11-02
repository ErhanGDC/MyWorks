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
            dynamic d = new Duck();
            d.Quack();
            d.Waddle();
            object o = new System.Text.StringBuilder();
            dynamic e = o;
            e.Append("hello");
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
