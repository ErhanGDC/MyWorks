using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Reflect_Exam
{
    public class Program
    {
        static void Main(string[] args)
        {
            int i = 42;
            System.Type type1 = i.GetType();

            int o = 42;
            MethodInfo compareToMethod = i.GetType().GetMethod("CompareTo",
            new Type[] { typeof(int) });
            int result = (int)compareToMethod.Invoke(i, new object[] { 41 });



            Assembly pluginAssembly = Assembly.Load("Reflect_Exam");
            var plugins = from type in pluginAssembly.GetTypes()
                          where typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface
                          select type;
            foreach (Type pluginType in plugins)
            {
                IPlugin plugin = Activator.CreateInstance(pluginType) as IPlugin;
            }
            DumpObject(plugins);

        }
        static void DumpObject(object obj)
        {
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType == typeof(int))
                {
                    Console.WriteLine(field.GetValue(obj));
                }
            }
        }
    }
    public interface IPlugin
    {
        string Name { get; }
        string Description { get; }
        bool Load(Program application);
    }
    public class MyPlugin : IPlugin
    {
        public string Name
        {
            get { return "MyPlugin"; }
        }
        public string Description
        {
            get { return "My Sample Plugin"; }
        }
        public bool Load(Program application)
        {
            return true;
        }
    }
}
