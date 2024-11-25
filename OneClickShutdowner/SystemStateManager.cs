using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace OneClickShutdowner
{
    public class SystemStateMananger
    {
        public static void Hibernate()
        {
            Application.SetSuspendState(PowerState.Hibernate, true, true);
        }

        public static void Sleep()
        {
            Application.SetSuspendState(PowerState.Suspend, true, true);
        }

        [DllImport("user32")]
        public static extern void LockWorkStation();
        [DllImport("user32")]
        public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);

        static int WM_SYSCOMMAND = 0x112;
        static int SC_MONITORPOWER = 0xF170;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        public static void Shutdown()
        {
            Process.Start("shutdown","/s /t 0");
        }

        public static void Restart()
        {
            Process.Start("shutdown", "/r /t 0");
        }

        public static void Logoff()
        {
            ExitWindowsEx(0, 0);
  
        }

        public static void Lock()
        {
            LockWorkStation();
        }

        public static void TurnOffMonitor()
        {
            Form f = new Form();
            bool turnOff = true;   //set true if you want to turn off, false if on
            SendMessage(f.Handle, (int)WM_SYSCOMMAND, (IntPtr)SC_MONITORPOWER, (IntPtr)(turnOff ? 2 : -1));
        }

    }
}
