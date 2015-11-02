using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Guid
{
    class Program
    {
        static void Main(string[] args)
        {
        //    Guid g = new Guid.NewGuid();
        //    Console.WriteLine(g.ToString());
        //    Console.ReadLine();
            Test<int> myTest = new Test<int>();
            myTest.SetValue(67);

            double x = double.NaN;
            Console.WriteLine(x==x);
            Console.WriteLine(x.Equals(x));
            Console.WriteLine(myTest.ToString());
            


            //Compare A value type and  A referance type
            var sb1 = new StringBuilder("foo");
            var sb2 = new StringBuilder("foo");
            Console.WriteLine(sb1==sb2);
            Console.WriteLine(sb1.Equals(sb2));
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("\n");

            //Area? otherArea = new Area?();
            //otherArea.HasValue && Equals(otherArea.Value);

            Area a1 = new Area(5,10);
            Area a2 = new Area(10, 5);

            Console.WriteLine(a1.Equals(a2));
            Console.WriteLine(a1==a2);

            Console.ReadLine();


        }
    }
    class Test<T> where T : IEquatable<T>
    {
        T _value;
        public void SetValue(T newValue)
        {
            if (!object.Equals(newValue,_value))
            {
                _value = newValue;
                OnValuechanged();
            }        
        }
        protected virtual void OnValuechanged() { }
    }

    public struct Area : IEquatable<Area>
    {
        public readonly int Measure1;
        public readonly int Measure2;

        public Area(int m1, int m2)
        {
            Measure1 = Math.Min(m1, m2);
            Measure2 = Math.Max(m1, m2);
        }

        public override bool Equals(object other)
        {
            if (!(other is Area)) return false;
            return Equals((Area) other); // calls method below
        }

        public bool Equals(Area other)
        {
            return Measure1 == other.Measure1 && Measure2 == other.Measure2;
        }

        public override int GetHashCode()
        {
            return Measure2 * 31 + Measure1; //31=some prime number
        }
        public static bool operator ==(Area a1, Area a2)
        { 
        return a1.Equals(a2);
        }

        public static bool operator !=(Area a1, Area a2)
        {
            return !a1.Equals(a2);
        }
    }
}
