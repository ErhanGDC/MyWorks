using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Discovery
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                AppDomain domain = AppDomain.CreateDomain("Plugin Domain");
                Discoverer d = (Discoverer)domain.CreateInstanceAndUnwrap(
                typeof(Discoverer).Assembly.FullName,
                typeof(Discoverer).FullName);
                string[] plugInTypeNames = d.GetPluginTypeNames("AllCapitals.dll");
                foreach (string s in plugInTypeNames)
                    Console.WriteLine(s); // Plugin.Extensions.AllCapitals
            }
        }
        public class Discoverer : MarshalByRefObject
        {
//            ITextPlugin plugin = (ITextPlugin)domain.CreateInstanceFromAndUnwrap
//("AllCapitals.dll", "Plugin.Extensions.AllCapitals");
            public string[] GetPluginTypeNames(string assemblyPath)
            {
                List<string> typeNames = new List<string>();
                Assembly a = Assembly.LoadFrom(assemblyPath);
                foreach (Type t in a.GetTypes())
                    if (t.IsPublic
                    && t.IsMarshalByRef
                    && typeof(ITextPlugin).IsAssignableFrom(t))
                    {
                        typeNames.Add(t.FullName);
                    }
                return typeNames.ToArray();
            }
        }
    }
}
