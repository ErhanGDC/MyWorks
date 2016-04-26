using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Exam2
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateAndRaise();
            Console.ReadLine();
        }
        static public void CreateAndRaise()
        {
            Pub p = new Pub();
            p.OnChange += (sender, e)
            => Console.WriteLine("Subscriber 1 called");
            p.OnChange += (sender, e)
            => { throw new Exception(); };
            p.OnChange += (sender, e)
            => Console.WriteLine("Subscriber 3 called");
            p.Raise();
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
    public class Pub
    {
        private event EventHandler<MyArgs> onChange = delegate { };
        public event EventHandler<MyArgs> OnChange
        {
            add
            {
                lock (onChange)
                {
                    onChange += value;
                }
            }
            remove
            {
                lock (onChange)
                {
                    onChange -= value;
                }
            }
        }
        public void Raise()
        {
            onChange(this, new MyArgs(42));
        }
    }
}
