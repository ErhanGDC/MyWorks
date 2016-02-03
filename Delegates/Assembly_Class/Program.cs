using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection; // Necessary for Assembly Info
using System.Security.Policy; // Woow
using System.Text;
using System.Threading.Tasks;

namespace Assembly_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly a = typeof(Program).Assembly;
            Assembly ab = typeof(Program).GetTypeInfo().Assembly;
            string v = a.GetName().Version.ToString(); // Trick ;)
            Publisher p = a.Evidence.GetHostEvidence<Publisher>();

            // This is too importtant Reflection on Runtime
            Type t = Assembly.LoadFrom(@"d:\temp\foo.dll").GetType("Foo");
            var foo = Activator.CreateInstance(t);


            //byte[] image = File.ReadAllBytes(assemblyPath);
            //Assembly a = Assembly.Load(image);

            //Type t = a.GetType("Namespace.TypeName");
            //IPluggable widget = (IPluggable)Activator.CreateInstance(t);
            //widget.ShowAboutBox();
        }
    }
}
