using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace BobsWindowAdjusterLib
{
    public static class WindowResizer
    {
        public static void Resize(Process process, int x, int y, int width, int height, bool redraw)
        {
            if(process != null && !process.HasExited)
            {
                var mainWindowHandle = process.MainWindowHandle;
                if(mainWindowHandle != null)
                {
                    MoveWindow(mainWindowHandle, x, y, width, height, redraw);
                }
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
    }
}
