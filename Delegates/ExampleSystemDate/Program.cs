using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ExampleSystemDate
{
    class Program
    {
        //[DllImport("kernel32.dll")]
        //static extern void GetSystemTime(SystemTime t);
        static void Main(string[] args)
        {
            //SystemTime t = new SystemTime();
            //GetSystemTime(t);
            //Console.WriteLine(t.Year);

        }
    }
    class CallbackFun
    {
        delegate bool EnumWindowsCallback(IntPtr hWnd, IntPtr lParam);
        [DllImport("user32.dll")]
        static extern int EnumWindows(EnumWindowsCallback hWnd, IntPtr lParam);
        static bool PrintWindow(IntPtr hWnd, IntPtr lParam)
        {
            Console.WriteLine(hWnd.ToInt64());
            return true;
        }
        //static void Main()
        //{
        //    EnumWindows(PrintWindow, IntPtr.Zero);
        //}
    }
}
