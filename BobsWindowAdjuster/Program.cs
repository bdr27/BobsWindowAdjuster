using BobsWindowAdjusterLib;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace BobsWindowAdjuster
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var sub = new ProcessSubsciber();
            Thread t = new Thread(sub.WaitForProcess);
            t.IsBackground = true;
            t.Start();
            Console.WriteLine("Press Enter To Quit");
            Console.ReadLine();

        }

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

    }
}
