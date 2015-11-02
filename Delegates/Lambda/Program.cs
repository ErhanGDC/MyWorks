using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    class Program
    {
        delegate int transFormers(int i);
        public static event EventHandler Clicked = delegate { };
        static void Main(string[] args)
        {
            transFormers sqr = x => x * x;
            Console.WriteLine(sqr(3));

            Func<int, int> sqr1 = (int x) => x * x;
            Console.WriteLine(sqr1(5));

            int factor = 2;
            Func<int, int> multiple = n => n * factor;
            Console.WriteLine(multiple(5));
            Console.WriteLine("-----------------------------------");


            int seed = 0;
            Func<int> natual = () => seed++;
            Console.WriteLine(natual());
            Console.WriteLine(natual());
            Console.WriteLine(natual());
            Console.WriteLine(natual());
            Console.WriteLine(seed);
            Console.WriteLine("-----------------------------------");

            Func<int> natural = Natural();
            Console.WriteLine(natural());
            Console.WriteLine(natural());
            Console.WriteLine(natural());
            Console.WriteLine("-----------------------------------");

            Action[] action=new Action[3];
            for (int i = 0; i < action.Length; i++)
            {
                action[i] = () => Console.WriteLine(i);
            }
            foreach (Action a in action)
            {
                a();
            }
            Console.WriteLine("-----------------------------------");



            Action[] action1 = new Action[3];
            for (int i = 0; i < action1.Length; i++)
            {
                int loopScope = i;
                action1[i] = () => Console.WriteLine(loopScope);
            }
            foreach (Action a in action1)
            {
                a();
            }
            Console.WriteLine("-----------------------------------");

            Action[] action2 = new Action[3];
            int ih = 0;
            foreach (char c in "abc")
            {
                action2[ih++] = () => Console.WriteLine(c);
            }
            foreach (Action a in action2)
            {
                a();
            }
            Console.WriteLine("-----------------------------------");

            Clicked += delegate { Console.WriteLine("clicked"); };


            Console.ReadLine();
        }
        static Func<int> Natural()
        {
            return () => { int seed = 0; return seed++; };
        }
    }
}
