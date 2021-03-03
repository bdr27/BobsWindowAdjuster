using System;
using System.Diagnostics;
using System.Management;

namespace BobsWindowAdjusterLib
{
    public class ProcessSubsciber
    {
        public void WaitForProcess()
        {
            ManagementEventWatcher startWatch = new ManagementEventWatcher(
                 new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace"));
                startWatch.EventArrived += new EventArrivedEventHandler(startWatch_EventArrived);
            startWatch.Start();
        }

        static void startWatch_EventArrived(object sender, EventArrivedEventArgs e)
        {
            Console.WriteLine("Process started: {0}"
                              , e.NewEvent.Properties["ProcessName"].Value);           
            if(e.NewEvent.Properties["ProcessName"].Value.ToString().ToLower().Contains("elitedangerous64"))
            {
                Console.WriteLine("It's elite");
                var id = (uint)e.NewEvent.Properties["ProcessID"].Value;
                var process = Process.GetProcessById(Convert.ToInt32(id));
                WindowResizer.MoveWindow(process.MainWindowHandle, -1920, 0, 4460, 1080, true);
            }
        }
    }
}
