using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dj_hero;
using WMPLib;
using Figgle;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace dj_hero
{
    public class Program
    {
        public static int width = 180;
        public static int height = 40;


        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(System.IntPtr hWnd, int cmdShow);

        private static void Maximize()
        {
            Process p = Process.GetCurrentProcess();
            ShowWindow(p.MainWindowHandle, 3); //SW_MAXIMIZE = 3
        }

        static void Main(string[] args)
        {

            Console.CursorVisible = false;

            Maximize(); 


            Audio.PrepareSongs();
            MenuView menuView = new MenuView();
            menuView.Init();




            Console.ReadKey();


        }
    }
}
