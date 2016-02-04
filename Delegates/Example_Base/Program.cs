using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_Base
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain newDomain = AppDomain.CreateDomain("New Domain");
            newDomain.ExecuteAssembly("test.exe");
            AppDomain.Unload(newDomain);


            AppDomain newDomain1 = AppDomain.CreateDomain("New Domain");
            newDomain1.DoCallBack(new CrossAppDomainDelegate(SayHello));
            AppDomain.Unload(newDomain1);
        }
        static void SayHello()
        {
            Console.WriteLine("Hi from " + AppDomain.CurrentDomain.FriendlyName);
        }
    }
}
