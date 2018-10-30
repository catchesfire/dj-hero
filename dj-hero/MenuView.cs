using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

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

            Elements.Add("play", new ViewElement((Console.WindowWidth / 2) - 10, Console.WindowHeight / 2 - 7, 21, 3, new List<string>()
            {
                @"___  _    ____ _   _  ",
                @"|__] |    |__|  \_/   ",
                @"|    |___ |  |   |    "
            }));
            Elements.Add("rank", new ViewElement((Console.WindowWidth / 2) - 10, Console.WindowHeight / 2 - 2, 20, 3, new List<string>()
            {
                @"____ ____ _  _ _  _ ",
                @"|__/ |__| |\ | |_/  ",
                @"|  \ |  | | \| | \_ "
            }));
            Elements.Add("exit", new ViewElement((Console.WindowWidth / 2) - 8, Console.WindowHeight / 2 + 3, 16, 3, new List<string>()
            {
                @"____ _  _ _ ___ ",
                @"|___  \/  |  |  ",
                @"|___ _/\_ |  |  "
            }));
            selectedElement = Elements[list[0]];

            Elements["Logo"].ForegroundColor = ConsoleColor.Red;
        }
        private Thread t;
        private Thread anim;
        private bool exit;

        private System.Timers.Timer animationTimer = new System.Timers.Timer(50);

        private static ViewElement animatedElem;

        private int animatedIndex = 0;

        private static ConsoleKeyInfo pressedKey;

        private void Animate(object sender, ElapsedEventArgs e)
        {
            Console.CursorVisible = false;
            for (int i = 0; i < animatedElem.Height; i++)
            {
                Console.SetCursorPosition(animatedElem.PosX + animatedIndex % animatedElem.Width, animatedElem.PosY + i);
                ConsoleColor color = animatedElem.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(animatedElem.Lines[i][animatedIndex % animatedElem.Width]);
                Console.ForegroundColor = color;
            }
            for (int i = 0; i < animatedElem.Height; i++)
            {
                Console.SetCursorPosition(animatedElem.PosX + (animatedIndex % animatedElem.Width) - 1, animatedElem.PosY + i);
                ConsoleColor color = animatedElem.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.White;
                if ((animatedIndex % animatedElem.Width) > 0)
                {
                    Console.Write(animatedElem.Lines[i][(animatedIndex % animatedElem.Width) - 1]);
                }
                else
                {
                    Console.Write(animatedElem.Lines[i][(animatedElem.Width - 1)]);
                }

            }
            animatedIndex++;

        }

        public void AnimateMenuItem()
        {
            animatedElem = selectedElement;

            animationTimer = new System.Timers.Timer(75);
            animationTimer.Elapsed += Animate;

            animationTimer.Start();
        }

        void StopAnimation()
        {
            animationTimer.Stop();
            animatedIndex = 0;
        }

        public void Init()
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

            Thread.Sleep(100);
            AnimateMenuItem();
            t.Start();

            exit = false;
            do
            {

                switch (pressedKey.Key)
                {
                    case ConsoleKey.D1:
                        //ts.Cancel();
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
            StopAnimation();
            if (counter % list.Length == 0)
            {
                t.Abort();
                exit = true;
                Menu.Play();
            }
            else if (counter % list.Length == 1)
            {
                t.Abort();
                exit = true;
                Menu.Rank();
            }
            else { Menu.Exit(); }
        }

        internal void MoveSelectedUp()
        {
            StopAnimation();
            selectedElement.Update();

            counter += list.Length - 1;
            int index = counter % list.Length;
            selectedElement = Elements[list[index]];
            AnimateMenuItem();
        }

        public void MoveSelectedDown()
        {
            StopAnimation();
            selectedElement.Update();
            selectedElement = Elements[list[++counter % list.Length]];
            AnimateMenuItem();
        }

        public override void Render(bool clear = true)
        {
            base.Render();
        }

    }
}
