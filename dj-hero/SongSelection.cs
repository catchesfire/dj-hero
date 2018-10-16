using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dj_hero
{
    class SongSelection
    {
        private static ConsoleKeyInfo pressedKey;

        public void Init()
        {
            SongSlectionView selectionView = new SongSlectionView();

            //Thread t = new Thread(delegate ()
            //{
            //    do
            //    {
            //        pressedKey = Console.ReadKey(true);

            //    } while (true);
            //});
            //t.Start();

             Song current = Song.songs[0];



            //Display songs 
            //set matchoptions 
            Audio.StartSong(current, false);
            Game game = Game.Instance;
            game.play();
        }
    }
}
