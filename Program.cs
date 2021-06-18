using System;
using System.Threading;

namespace MoveConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int wieght = 300;//y
            int height = 300;//x
            
            ConsoleChange cONSOLE = new ConsoleChange(wieght,height,300,300);

            
            int speed = 15;
            int x=0;
            int y=0;

            Console.Write("READY? ");
            Console.ReadLine();
            
            cONSOLE.ChangeLocationConsole(x,y);
            while (true)
            {
                while (y < 1080-1.5*wieght-50)
                {
                    y += speed;
                    cONSOLE.ChangeLocationConsole(x, y);
                    Thread.Sleep(1);
                }
                
                while (x < 1920 -  2.5*wieght+80)
                {
                    x += speed;
                    cONSOLE.ChangeLocationConsole(x, y);
                    Thread.Sleep(1);
                }
                
                while (y > 0)
                {
                    y -= speed;
                    cONSOLE.ChangeLocationConsole(x, y);
                    Thread.Sleep(1);
                }
                while (x > 0)
                {
                    x -= speed;
                    cONSOLE.ChangeLocationConsole(x, y);
                    Thread.Sleep(1);
                }
            }
        }
    }
    public class ConsoleChange
    {
        
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        static readonly IntPtr HWND_TOP = new IntPtr(0);
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 SWP_NOZORDER = 0x0004;
        const UInt32 SWP_NOREDRAW = 0x0008;
        const UInt32 SWP_NOACTIVATE = 0x0010;
        const UInt32 SWP_FRAMECHANGED = 0x0020;
        const UInt32 SWP_SHOWWINDOW = 0x0040;
        const UInt32 SWP_HIDEWINDOW = 0x0080;
        const UInt32 SWP_NOCOPYBITS = 0x0100;
        const UInt32 SWP_NOOWNERZORDER = 0x0200;
        const UInt32 SWP_NOSENDCHANGING = 0x0400;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private int x = 0;
        private int y = 0;

        private int height;
        private int wight;
        
        public ConsoleChange(int height, int wight, int x, int y)
        {
            this.height = height;
            this.wight = wight;
            this.x = x;
            this.y = y;
        }
        
        public ConsoleChange(int height, int wight)
        {
            this.height = height;
            this.wight = wight;
        }

        public void ChangeLocationConsole(int x, int y)
        {
            IntPtr ConsoleHandle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            const UInt32 WINDOW_FLAGS = SWP_SHOWWINDOW;

            // Здесь 0,0 - позиция окна (x, y)     700 - ширина       600 - высота
            SetWindowPos(ConsoleHandle, HWND_NOTOPMOST, x, y, height, wight, WINDOW_FLAGS);
        }
        
        public void ChangeSizeConsole(int wight, int height)
        {
            IntPtr ConsoleHandle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            const UInt32 WINDOW_FLAGS = SWP_SHOWWINDOW;

            // Здесь 0,0 - позиция окна (x, y)     700 - ширина       600 - высота
            SetWindowPos(ConsoleHandle, HWND_NOTOPMOST, x, y, height, wight, WINDOW_FLAGS);
        }
    }
}
