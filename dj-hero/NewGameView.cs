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
        private ViewElement border;
        private ViewElement _logo;
        private Thread t;
        private bool exit;
        private ConsoleKeyInfo pressedKey;

        public NewGameView()
        {
            pressedKey = new ConsoleKeyInfo();
            nick = "";

            _logo = new ViewElement((Console.WindowWidth / 2) - (logo[0].Length / 2), 1, logo[0].Length, logo.Count, logo);
            border = new ViewElement(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 - 2, 40, 5, DrawRect(40, 5));
            header = new ViewElement(Console.WindowWidth / 2 - 5, border.PosY - 2, 10, 1, new List<string>() { "Podaj nick" });
            nickname = new ViewElement(border.PosX + 2, border.PosY + 2, 36, 1, new List<string>() { "" });

            _logo.ForegroundColor = ConsoleColor.Red;

            Elements.Add("Logo", _logo);
            Elements.Add("Header", header);
            Elements.Add("NicknameBorder", border);
            Elements.Add("Nickname", nickname);

            Elements.Add("alert", new ViewElement(Console.WindowWidth / 2 - 18, Console.WindowHeight / 2 + 6, 40, 1, new List<string>()
                {"Invalid nickname" }));
        }


        public void Init()
        {
            Render();
            Elements["alert"].Clear();


            Console.SetCursorPosition(nickname.PosX, nickname.PosY);
            Console.CursorVisible = true;

            exit = false;
            do
            {
                pressedKey = Console.ReadKey(false);

                switch (pressedKey.Key)
                {
                    case ConsoleKey.Escape:
                        exit = true;
                        ExitAction();
                        pressedKey = new ConsoleKeyInfo();
                        break;
                    case ConsoleKey.Enter:
                        EnterAction();
                        break;
                    case ConsoleKey.Backspace:
                        if(nick.Length > 0)
                        {
                            nickname.Lines[0] = nick.Remove(nick.Length - 1, 1);
                            nick = nickname.Lines[0];
                            nickname.Update();
                            Console.SetCursorPosition(border.PosX + 2 + nickname.Lines[0].Length, border.PosY + 2);
                        }
                        Console.SetCursorPosition(border.PosX + 2 + nickname.Lines[0].Length, border.PosY + 2);
                        break;
                    default:
                        if (char.IsLetterOrDigit(pressedKey.KeyChar))
                        {
                            if(nick.Length < nickname.Width)
                            {
                                nick += pressedKey.KeyChar;
                                nickname.Lines[0] = nick;
                            }
                        }
                        break;
                }
            } while (!exit);

        }

        private void ExitAction()
        {
            exit = true;
            Console.CursorVisible = false;
            MenuView menuView = new MenuView();
            menuView.Init();
        }


        private bool validationNickname()
        {




            return true;
        }

        private void EnterAction()
        {
            if(nick.Trim().Length <= 0)
            {
                //cw invalid name
                Elements["alert"].Update();



                Console.SetCursorPosition(nickname.PosX + 2, nickname.PosY + 2);
                return;
            }

            exit = true;
            Console.CursorVisible = false;
            SongSelectionView songSelectionView = new SongSelectionView(nick.Trim());
            songSelectionView.Init();
        }

        public string GetNick()
        {
            return nick;
        }
    }
}
