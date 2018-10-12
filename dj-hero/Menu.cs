using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dj_hero
{
    public static class Menu
    {


        private static ConsoleKeyInfo pressedKey;

        public static void Init()
        {
            MenuView menuView = new MenuView();
            menuView.Render();

            Thread t = new Thread(delegate ()
            {
                do
                {
                    pressedKey = Console.ReadKey(true);

                    Thread.Sleep(10);


                } while (true);
            });
            t.Start();

            Boolean exit = false;
            do
            {
                switch (pressedKey.Key)
                {
                    case ConsoleKey.D1:
                        //ts.Cancel();
                        t.Abort();
                        exit = true;
                        Menu.Play();
                        break;
                    case ConsoleKey.D2:
                        Menu.Options();
                        break;
                    case ConsoleKey.D3:
                        Menu.Rank();
                        break;
                    case ConsoleKey.D4:
                        Menu.Exit();
                        break;

                }
            } while (!exit);
        }


        // switch to window difficult chose
        public static void Play()
        {
            SongSelection songSelection = new SongSelection();
            songSelection.Init();
        }

        public static void Options()
        {

        }

        public static void Rank()
        {

        }

        public static void Exit()
        {
            System.Environment.Exit(1);
        }

    }
}
