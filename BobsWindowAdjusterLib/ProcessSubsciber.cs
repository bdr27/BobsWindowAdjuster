using System;
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
        }
    }
}
