using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dj_hero;
using WMPLib;
using Figgle;
namespace dj_hero
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.CursorVisible = false;
            Console.WriteLine("Hello DJ-Hero");
            Console.WriteLine();
            // Menu.Init();
            Song.PrepareSongs();

            //Audio.StartSong(Song.mainmenusong, true);
            //Console.ReadKey();
            //Console.WriteLine("Tutaj ktos zle wcisnal literke XD");
            //Audio.Noise();

            Ranking r = new Ranking(Audio.GetSongList()[0]);

            r.AddRecord("marcin", 2137);
            r.AddRecord("pawelek", 2);
            r.AddRecord("wojtek", 512);

            r.AddRecord("menekin", 21373);

            r.Print();
            Console.ReadKey();

            //menu.Render();

        }
    }
}
