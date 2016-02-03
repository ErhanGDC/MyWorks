using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Thread_Basic
{
    class Program
    {
        static readonly object _Mylocker = new object();
        public void test()
        {
            lock (_Mylocker)
            {
                Console.WriteLine("This is thread safe event");
            }
        }

        static void Main(string[] args)
        {
            
        }
    }
//    This class is not thread-safe: if Go was called by two threads simultaneously, it would
//be possible to get a division-by-zero error, because _val2 could be set to zero in one
//thread right as the other thread was in between executing the if statement and
//Console.WriteLine. Here’s how lock fixes the problem:
    class ThreadUnsafe
    {
        static int _val1 = 1, _val2 = 1;
        static void Go()
        {
            if (_val2 != 0) Console.WriteLine(_val1 / _val2);
            _val2 = 0;
        }
    }

//Only one thread can lock the synchronizing object (in this case, _locker) at a time,
//and any contending threads are blocked until the lock is released. If more than one
//thread contends the lock, they are queued on a “ready queue” and granted the lock
//on a first-come, first-served basis.1 Exclusive locks are sometimes said to enforce
//serialized access to whatever’s protected by the lock, because one thread’s access
//cannot overlap with that of another. In this case, we’re protecting the logic inside
//the Go method, as well as the fields _val1 and _val2.
    class ThreadSafe
    {
        static readonly object _locker = new object();
        static int _val1, _val2;
        static void Go()
        {
            lock (_locker)
            {
                if (_val2 !=0)
                {
                    Console.WriteLine(_val1/_val2);
                    _val2 = 0;
                }
            }
        }
    }
    // Dead Lock  The popular advice, “lock objects in a consistent order to avoid deadlocks,”
    public class DeadLock_Example
    {
//    object locker1 = new object();
//object locker2 = new object();
//new Thread (() => {
//lock (locker1)
//{
//Thread.Sleep (1000);
//lock (locker2); // Deadlock
//}
//}).Start();
//lock (locker2)
//{
//Thread.Sleep (1000);
//lock (locker1); // Deadlock
//}
    }
}
