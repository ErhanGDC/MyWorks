using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateAndRaise(); 
            CreateAndRaise1();
        }
        public static void CreateAndRaise()
        {
            Pub pop = new Pub();
            pop.OnChanged += () => Console.WriteLine("Event raised to method 1");
            pop.OnChanged += () => Console.WriteLine("Event raised to method 2");
            pop.Raise();

            Console.ReadLine();
        }
        public static  void CreateAndRaise1()
        {
        //    Pub p = new Pub();
        //  //  p.OnChanged += ( e)
        //    => Console.WriteLine("Event raised: {0}", e.Value);
        //    p.Raise();

            Console.ReadLine();
        }
    }
    public class Pub
    {
        //public Action onChanged { get; set; }
        public event Action OnChanged = delegate { };
        public void Raise()
        {
            OnChanged();
        }

    }

    public class MyArgs : EventArgs
    {
        public MyArgs(int value)
        {
            Value = value;
        }
        public int Value { get; set; }
    }
    public class Pub1
    {
        public event EventHandler<MyArgs> OnChange = delegate { };
        public void Raise()
        {
            OnChange(this, new MyArgs(67));
        }
    }


}
