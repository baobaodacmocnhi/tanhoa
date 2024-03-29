﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ThuTien
{
    static class Program
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetForegroundWindow(System.IntPtr mwh);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var me = System.Diagnostics.Process.GetCurrentProcess();
            var arrProcesses = System.Diagnostics.Process.GetProcessesByName(me.ProcessName);
            for (var i = 0; i < arrProcesses.Length; i++)
            {
                if (arrProcesses[i].Id != me.Id)
                {
                    SetForegroundWindow(arrProcesses[i].MainWindowHandle);
                    return;
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
