using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dj_hero
{
    public class SongSelectionView: View
    {
        private int counter = 0;

        private static ConsoleKeyInfo pressedKey;
        public List<Song> songsList;
        SongView selectedSong;
        private Thread t;
        private bool exit;
        List<SongView> songViewsList = new List<SongView>();
        private string nickname;


        public SongSelectionView(string _nickname)
        {
            pressedKey = new ConsoleKeyInfo();
            songsList = Audio.GetSongList();
            nickname = _nickname;
            int x = Console.WindowWidth / 2 + 1;
            int y = 0;
            foreach (Song song in songsList)
            {
                songViewsList.Add(new SongView(x, y, song));
                y += 5;

            }

            selectedSong = songViewsList[0];
        }

        public void Init()
        {
            Elements.Add("Logo", new ViewElement((Console.WindowWidth / 4) - (logo[0].Length / 2), 1, logo[0].Length, logo.Count, logo));
            Elements["Logo"].ForegroundColor = ConsoleColor.Red;
            List<string> h1 = new List<string>()
            {
                "Witaj " + nickname
            };
            List<string> h2 = new List<string>()
            {
                "Wybierz melodie"
            };
            Elements.Add("H1", new ViewElement((Console.WindowWidth / 4) - (h1[0].Length / 2), Console.WindowHeight / 2, h1[0].Length, 1, h1));
            Elements.Add("H2", new ViewElement((Console.WindowWidth / 4) - (h2[0].Length / 2), Console.WindowHeight / 2 + 1, h2[0].Length, 1, h2));
            Render();
            foreach (SongView sView in songViewsList)
            {
                sView.Render(false);
            }

            selectedSong.SetTick();

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
                    case ConsoleKey.Escape:
                        exit = true;
                        ExitAction();
                        pressedKey = new ConsoleKeyInfo();
                        break;
                }
            } while (!exit);

        }

        private void ExitAction()
        {
            exit = true;
            t.Abort();
            Console.CursorVisible = false;
            MenuView menuView = new MenuView();
            menuView.Init();
        }

        private void EnterAction()
        {
            //set matchoptions 
            //Audio.StartSong(selectedSong);
            t.Abort();
            exit = true;
            MatchOption matchOption = new MatchOption(selectedSong.song);
            matchOption.nickname = nickname;
            Game game = new Game(matchOption, selectedSong.song);
            //game.play();
        }

        private void MoveSelectedUp()
        {
            selectedSong.RemoveTick();
            counter += songViewsList.Count - 1;
            int index = counter % songViewsList.Count;
            selectedSong = songViewsList[index];
            selectedSong.SetTick();
        }

        private void MoveSelectedDown()
        {
            selectedSong.RemoveTick();
            selectedSong = songViewsList[++counter % songViewsList.Count];
            selectedSong.SetTick();
        }
    }
}
