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
            Elements.Add("logo", new ViewElement((Console.WindowWidth - 40) / 2, 0, 80, 6, 
                new List<string>()
                {
                    @"______  ___   _   _  ___________ _____",
                    @"|  _  \|_  | | | | ||  ___| ___ \  _  |",
                    @"| | | |  | | | |_| || |__ | |_/ / | | |",
                    @"| | | |  | | |  _  ||  __||    /| | | |",
                    @"| |/ /\__/ / | | | || |___| |\ \\ \_/ /",
                    @"|___/\____/  \_| |_/\____/\_| \_|\___/"
                }
                ));
            
            Elements.Add("play", new ViewElement(20, 10, 7, 1, new List<string>() { "1. Play" }));
            Elements.Add("rank", new ViewElement(20, 12, 7, 1, new List<string>() { "2. Rank" }));
            Elements.Add("exit", new ViewElement(20, 14, 8, 1, new List<string>() { "3. Exit" }));
            selectedElement = Elements[list[0]];
        }
        private Thread t;
        private Boolean exit;


        private static ConsoleKeyInfo pressedKey;

        public  void Init()
        {
            Render();

            t = new Thread(delegate ()
            {
                do
                {
                    pressedKey = Console.ReadKey(true);

                    Thread.Sleep(10);


                } while (true);
            });
            t.Start();

            exit = false;
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
                        Menu.Rank();
                        break;
                    case ConsoleKey.D3:
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
                        EnterAction();
                        break;

                }
            } while (!exit);
        }


        private void EnterAction()
        {
            if(counter % list.Length == 0)
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
