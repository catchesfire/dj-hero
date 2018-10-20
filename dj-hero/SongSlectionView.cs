using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dj_hero
{
    public class SongSlectionView: View
    {
        private int counter = 0;

        private static ConsoleKeyInfo pressedKey;
        public List<Song> songsList;
        SongView selectedSong;
        private Thread t;
        private bool exit;
        List<SongView> songViewsList = new List<SongView>();
        private string nickname;


        public SongSlectionView(string _nickname)
        {
            pressedKey = new ConsoleKeyInfo();
            songsList = Audio.GetSongList();
            nickname = _nickname;
            int x = Console.WindowWidth / 2 + 1;
            int y = 2;
            foreach (Song song in songsList)
            {
                songViewsList.Add(new SongView(x, y, song));
                y += 5;

            }

            selectedSong = songViewsList[0];
        }

        public void Init()
        {
            Clear();
            Elements.Add("nickname",new ViewElement(20,1,30,1, new List<string>()
                {
                    "Witaj " + nickname + " wybierz melodie"
                }
                ));
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
