using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflactionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t1 = DateTime.Now.GetType(); // Type obtained at runtime
            Type t2 = typeof(DateTime); // Type obtained at compile time

            Type t3 = typeof(DateTime[]); // 1-d Array type
            Type t4 = typeof(DateTime[,]); // 2-d Array type
            Type t5 = typeof(Dictionary<int, int>); // Closed generic type
            Type t6 = typeof(Dictionary<,>); // Unbound generic type
         
            Type t = Assembly.GetExecutingAssembly().GetType("Delegates.ReflactionExample");

            Type stringType = typeof(string);
            string name = stringType.Name; // String
            Type baseType = stringType.BaseType; // typeof(Object)
            Assembly assem = stringType.Assembly; // mscorlib.dll
            bool isPublic = stringType.IsPublic; // true

            Type stringType1 = typeof(string);
            string name1 = stringType.Name;
            Type baseType1 = stringType.GetTypeInfo().BaseType;
            Assembly assem1 = stringType.GetTypeInfo().Assembly;
            bool isPublic1 = stringType.GetTypeInfo().IsPublic;

            Type simpleArrayType = typeof(int).MakeArrayType();
            Console.WriteLine(simpleArrayType == typeof(int[])); // True
            Type e = typeof(int[]).GetElementType(); // e == typeof (int)

            foreach (Type iType in typeof(Guid).GetInterfaces())
                Console.WriteLine(iType.Name);

            // Real Reflaction  Can you create an instance of object without constructor ???????
            int i = (int)Activator.CreateInstance(typeof(int));
            DateTime dt = (DateTime)Activator.CreateInstance(typeof(DateTime),
            2000, 1, 1);

            // Fetch the constructor that accepts a single parameter of type string:
           // ConstructorInfo ci = typeof().GetConstructor(new[] { typeof(string) });

            // Construct the object using that overload, passing in null:
            //object foo = ci.Invoke(new object[] { null });

            //ConstructorInfo ci1 = typeof().GetTypeInfo().DeclaredConstructors
            //.FirstOrDefault(c =>
            //c.GetParameters().Length == 1 &&
            //c.GetParameters()[0].ParameterType == typeof(string));

            MemberInfo[] members = typeof(Walnut).GetMembers();
            foreach (MemberInfo m in members)
                Console.WriteLine(m);

            IEnumerable<MemberInfo> members1 =typeof(Walnut).GetTypeInfo().DeclaredMembers;

            string s74 = "Hello";
            int length = s74.Length;
            //Here’s the same thing performed dynamically with reflection:
            object s67 = "Hello";
            PropertyInfo prop = s67.GetType().GetProperty ("Length");
            int length67 = (int) prop.GetValue (s67, null); // 5

            // This is important to understand the System.Linq.Expressions
            int[] source = { 3, 4, 5, 6, 7, 8 };
            Func<int, bool> predicate = n => n % 2 == 1;
            var sourceExpr = Expression.Constant (source);
            var predicateExpr = Expression.Constant (predicate);
            var callExpression = Expression.Call (
            typeof(Enumerable), "Where", new[] { typeof(int) }, // Closed generic arg type.
            sourceExpr, predicateExpr);
        }
    }
   public class Walnut
    {
        private bool cracked;
        public void Crack() { cracked = true; }
    }
}
