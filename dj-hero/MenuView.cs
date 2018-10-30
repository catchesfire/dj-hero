using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dj_hero
{
    public class MenuView : View
    {
        private ViewElement selectedElement;
        string[] list = { "play", "rank", "exit" };
        private int counter = 0;
        public MenuView()
        {
            Elements.Add("Logo", new ViewElement((Console.WindowWidth / 2) - (logo[0].Length / 2), 1, logo[0].Length, logo.Count, logo));
            Elements.Add("play", new ViewElement(20, 10, 7, 1, new List<string>() { "1. Graj" }));
            Elements.Add("rank", new ViewElement(20, 12, 10, 1, new List<string>() { "2. Ranking" }));
            Elements.Add("exit", new ViewElement(20, 14, 8, 1, new List<string>() { "3. Wyjdź" }));
            selectedElement = Elements[list[0]];

            Elements["Logo"].ForegroundColor = ConsoleColor.Red;
        }
        private Thread t;
        private bool exit;


        private static ConsoleKeyInfo pressedKey;

        public  void Init()
        {
            Audio.StartServiceTrack("menu", true);
            pressedKey = new ConsoleKeyInfo();
            Render();

            t = new Thread(delegate ()
            {
                do
                {
                    pressedKey = Console.ReadKey(true);


                } while (true);
            });
            t.Start();

            exit = false;
            do
            {

                switch (pressedKey.Key)
                {
                    case ConsoleKey.D1:
                        Audio.StopTrack();
                        t.Abort();
                        exit = true;
                        Menu.Play();
                        break;
                    case ConsoleKey.D2:
                        Audio.StopTrack();

                        Menu.Rank();
                        pressedKey = new ConsoleKeyInfo();

                        break;
                    case ConsoleKey.D3:
                        Menu.Exit();
                        break;
                    case ConsoleKey.Escape:
                        Menu.Exit();
                        break;
                    case ConsoleKey.DownArrow:
                        MoveSelectedDown();
                        pressedKey = new ConsoleKeyInfo();
                        break;
                    case ConsoleKey.UpArrow:
                        MoveSelectedUp();
                        pressedKey = new ConsoleKeyInfo();
                        break;
                    case ConsoleKey.Enter:
                        Audio.StopTrack();

                        EnterAction();
                        break;

                }


            } while (!exit);
        }


        private void EnterAction()
        {
            if (counter % list.Length == 0)
            {
                t.Abort();
                exit = true;
                Menu.Play();
            }else if(counter % list.Length == 1)
            {
                t.Abort();
                exit = true;
                Menu.Rank();
            }
            else { Menu.Exit(); }
        }

        internal void MoveSelectedUp()
        {
            selectedElement.Update();

            counter += list.Length - 1;
            int index = counter % list.Length;
            selectedElement = Elements[list[index]];
            selectedElement.UpdateReverseColours();
        }

        public void MoveSelectedDown()
        {
            selectedElement.Update();
            selectedElement = Elements[list[++counter % list.Length]];
            selectedElement.UpdateReverseColours();
        }

        public override void Render(bool clear = true)
        {
            base.Render();
            selectedElement.UpdateReverseColours();


            //Console.WriteLine("LOGO");
            //Console.WriteLine("1.Play");
            //Console.WriteLine("2.Options");
            //Console.WriteLine("3.rank");
            //Console.WriteLine("4.Exit");
        }

    }
}
