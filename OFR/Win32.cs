using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OFR
{
    class Win32
    {
        //Rest of this code in located in the class itself
        public const int WS_EX_TRANSPARENT = 0x00000020;
        public const int GWL_EXSTYLE = (-20);
        public const int WS_EX_TOPMOST = 0x00000008;
        public const int WS_EX_LAYERED = 0x00000002;

        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hwnd,int index);

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hwnd,int index, int newStyle);


        public static void makeTransparent(IntPtr hwnd)
        {
            // Change the extended window style to include WS_EX_TRANSPARENT
        
            int extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
            
        Win32.SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle |WS_EX_TRANSPARENT | WS_EX_LAYERED | WS_EX_TOPMOST);



        }
        public class MoveToForeground
        {
            [DllImportAttribute("User32.dll")]
            private static extern int FindWindow(String ClassName, String WindowName);

            const int SWP_NOMOVE = 0x0002;
            const int SWP_NOSIZE = 0x0001;
            const int SWP_SHOWWINDOW = 0x0040;
            const int SWP_NOACTIVATE = 0x0010;
            [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
            public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

            public static void DoOnProcess(string processName)
            {
                var allProcs = Process.GetProcessesByName(processName);
                if (allProcs.Length > 0)
                {
                    Process proc = allProcs[0];
                    int hWnd = FindWindow(null, proc.MainWindowTitle.ToString());
                    // Change behavior by settings the wFlags params. See http://msdn.microsoft.com/en-us/library/ms633545(VS.85).aspx
                    SetWindowPos(new IntPtr(hWnd), 0, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW | SWP_NOACTIVATE);
                }
            }
        }
    }
}
