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


        public EndGameView(int _points, Song _song, MatchOption _matchOptions)
        {
            points = _points;
            song = _song;
            matchOptions = _matchOptions;

            Elements.Add("title", new ViewElement(Console.WindowWidth / 2 - 6, Console.WindowHeight / 2 - 10, 10, 3, new List<string>() { "Koniec gry", "play again - Enter or R", "back to menu - esc" }));

            Elements.Add("points", new ViewElement(Console.WindowWidth / 2 - 2, Console.WindowHeight / 2 , 6, 2, new List<string>()
                {
                    @"SCORE:",
                    @""+points.ToString()
                }
                ));

            init();
        }

        private void init()
        {
            Render();

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
                    case ConsoleKey.Enter:
                        exit = true;
                        EnterAction();
                        break;
                    case ConsoleKey.R:
                        exit = true;
                        EnterAction();
                        break;

                }
            } while (!exit);


        }

        private void EnterAction()
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
