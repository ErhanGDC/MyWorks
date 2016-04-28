using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Attribute
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    [Serializable]
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //[Conditional(“CONDITION1”), Conditional(“CONDITION2”)]
        [assembly: AssemblyTitle("ClassLibrary1")]
        [assembly: AssemblyDescription("")]
        [assembly: AssemblyConfiguration("")]
        [assembly: AssemblyCompany("")]
        [assembly: AssemblyProduct("ClassLibrary1")]
        [assembly: AssemblyCopyright("Copyright © 2013")]
        [assembly: AssemblyTrademark("")]
        [assembly: AssemblyCulture("")]
        public void MyMethod() { }
    }
}
