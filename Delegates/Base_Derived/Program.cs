using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Derived
{
    class Program
    {
        static void Main(string[] args)
        {
            Base1 b = new Base1();
            b.Execute();
            b = new Derived1();
            b.Execute();
        }
    }
    class Base
    {
        protected virtual void Execute()
        { }
    }
    class Derived : Base
    {
        protected override void Execute()
        {
            Log("Before executing");
            base.Execute();
            Log("After executing");
        }
        private void Log(string message) { /* some logging code */ }
    }


    // If a base class doesn’t declare a method as virtual, a derived class can’t override the method. It can, however, use the new keyword, 
    // which explicitly hides the member from a base class (this is different from using the new keyword to create a new instance of an object). 
    //This can cause some tricky situations, as Listing 2-48 shows.
    //NAME HIDING
    class Base1
    {
        public void Execute() { Console.WriteLine("Base1.Execute"); }
    }
    class Derived1 : Base1
    {
        public new void Execute() { Console.WriteLine("Derived1.Execute"); }
    }
}
