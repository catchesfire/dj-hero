using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dj_hero
{
    public class RankingView : View
    {

        List<SongView> songViewsList = new List<SongView>();
        private static ConsoleKeyInfo pressedKey;
        public List<Song> songsList;
        SongView selectedSong;

        private int counter = 0;
        private Thread t;
        bool exit;

        public RankingView()
        {

            songsList = Audio.GetSongList();
            songViewsList = new List<SongView>();

            string h1 = "Im udało się uciec";
            string h2 = "Wybierz piosenke, aby przejsc do rankingu.";

            Elements.Add("H1", new ViewElement(Console.WindowWidth / 2 - h1.Length / 2, 3, h2.Length, 1, new List<string>() { h1 }));
            Elements.Add("H2", new ViewElement(5, 5, h2.Length, 1, new List<string>() { h2 }));

            Audio.StartServiceTrack("rank");

            int y = 7;

            foreach (Song song in songsList)
            {
                songViewsList.Add(new SongView(10, y, song));
                y += 5;
            }

            selectedSong = songViewsList[0];
            selectedSong.SetTick();

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

        public void Init()
        {
           

            
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
            t.Abort();
            exit = true;

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

        public override void Render(bool clear = true)
        {
            base.Render(clear);

            foreach (SongView sView in songViewsList)
            {
                sView.Render(false);
            }
        }


    }
}
