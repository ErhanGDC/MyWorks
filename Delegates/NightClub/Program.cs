using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NightClub
{
    class Program
    {
        static void Main(string[] args)
        {
            // Too nice example =)
            TheClub club = new TheClub();
            for (int i = 1; i <= 5; i++) new Thread(TheClub.Enter).Start(i);
            Console.ReadLine();
        }
    }
    class TheClub // No door lists!
    {
        static SemaphoreSlim _sem = new SemaphoreSlim(3); // Capacity of 3
       
     public static void Enter(object id)
        {
            Console.WriteLine(id + " wants to enter");
            _sem.Wait();
            Console.WriteLine(id + " is in!"); // Only three threads
            Thread.Sleep(1000 * (int)id); // can be here at
            Console.WriteLine(id + " is leaving"); // a time.
            _sem.Release();
        }
    }


    //Another Example
    class SlimDemo
    {
        static ReaderWriterLockSlim _rw = new ReaderWriterLockSlim();
        static List<int> _items = new List<int>();
        static Random _rand = new Random();
        //static void Main()
        //{
        //    new Thread(Read).Start();
        //    new Thread(Read).Start();
        //    new Thread(Read).Start();
        //    new Thread(Write).Start("A");
        //    new Thread(Write).Start("B");
        //}
        static void Read()
        {
            while (true)
            {
                _rw.EnterReadLock();
                foreach (int i in _items) Thread.Sleep(10);
                _rw.ExitReadLock();
            }
        }
        static void Write(object threadID)
        {
            while (true)
            {
                int newNumber = GetRandNum(100);
                _rw.EnterWriteLock();
                _items.Add(newNumber);
                _rw.ExitWriteLock();
                Console.WriteLine("Thread " + threadID + " added " + newNumber);
                Thread.Sleep(100);
            }
        }
        static int GetRandNum(int max) { lock (_rand) return _rand.Next(max); }
    }
}
