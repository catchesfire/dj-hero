using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dj_hero
{
    public class NewGameView : View
    {

        private string nick;

        private ViewElement header;
        private ViewElement nickname;

        public NewGameView()
        {
            header = new ViewElement((Console.WindowWidth - 5) / 2, 3, 10, 1, new List<string>() { "Podaj nick" });
            nickname = new ViewElement(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 - 2, 40, 5, new List<string>()
            {
                @"╔══════════════════════════════════════╗",
                @"║                                      ║",
                @"║                                      ║",
                @"║                                      ║",
                @"╚══════════════════════════════════════╝"
            }
            );

            Elements.Add("Header", header);
            Elements.Add("Nickname", nickname);
        }

        static IntPtr ConsoleWindowHnd = GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("User32.Dll")]
        private static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

        public void Init()
        {
            Console.SetCursorPosition(nickname.PosX + 2, nickname.PosY + 2);
            Console.CursorVisible = true;
            nick = Console.ReadLine();
        }

        public string GetNick()
        {
            return nick;
        }
    }
}
