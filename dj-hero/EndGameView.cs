using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_hero
{
    public class EndGameView : View
    {
        private int points;
        private ConsoleKeyInfo pressedKey;
        private bool exit;
        private Song song;
        MatchOption matchOptions;
        private int counter = 0;


        string[] list = { "playAgain", "backToMenu", "exit" };
        private ViewElement selectedElement;



        public EndGameView(int _points, Song _song, MatchOption _matchOptions)
        {
            points = _points;
            song = _song;
            matchOptions = _matchOptions;


            Elements.Add("title", new ViewElement(20, 4, 7, 1, new List<string>() { "GAME OVER" }));
            Elements.Add("playAgain", new ViewElement(20, 10, 7, 1, new List<string>() { "Play again" }));
            Elements.Add("backToMenu", new ViewElement(20, 12, 7, 1, new List<string>() { "Back to menu" }));
            Elements.Add("exit", new ViewElement(20, 14, 8, 1, new List<string>() { "Exit" }));

            Elements.Add("points", new ViewElement(20, 20, 6, 2, new List<string>()
                {
                    @"SCORE:",
                    @""+points.ToString()
                }
                ));
            selectedElement = Elements[list[0]];

            init();
        }

        private void init()
        {
            Render();
            selectedElement.UpdateReverseColours();


            exit = false;
            do
            {
                pressedKey = Console.ReadKey(true);

                switch (pressedKey.Key)
                {
                    case ConsoleKey.Escape:
                        exit = true;
                        ExitAction();
                        pressedKey = new ConsoleKeyInfo();
                        break;
                    case ConsoleKey.R:
                        exit = true;
                        PlayAgain();
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
                        exit = true;
                        EnterAction();
                        break;

                }
            } while (!exit);


        }


        private void EnterAction()
        {
            if (counter % list.Length == 0)
            {
                PlayAgain();
            }
            else if (counter % list.Length == 1)
            {
                ExitAction();
                pressedKey = new ConsoleKeyInfo();
            }
            else { System.Environment.Exit(1); }
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



        private void PlayAgain()
        {
            Game game = new Game(matchOptions, song);
            game.play();
        }

        private void ExitAction()
        {
            exit = true;
            MenuView menuView = new MenuView();
            menuView.Init();
        }

    }
}
