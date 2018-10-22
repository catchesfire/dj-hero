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
    public class Program
    {
        public static int width = 180;
        public static int height = 40; 

        static void Main(string[] args)
        {

            Console.CursorVisible = false;

            Console.SetWindowSize(width, height);
            Audio.PrepareSongs();
            MenuView menuView = new MenuView();
            menuView.Init();


            //Audio.StartSong(Song.mainmenusong, true);
            //Console.ReadKey();
            //Console.WriteLine("Tutaj ktos zle wcisnal literke XD");
            //Audio.Noise();


            //Ranking r = new Ranking(Audio.GetSongList()[0]);

            //r.AddRecord("marcin", 1);
            //r.AddRecord("pawelek", 2);
            //r.AddRecord("wojtek", 3);
            //r.AddRecord("menekin", 4);
            //r.AddRecord("menekin", 5);
            //r.AddRecord("menekin", 6);

            //r.AddRecord("menekin", 7);
            //r.AddRecord("menekin", 8);

            //r.AddRecord("menekin", 10);
            //r.AddRecord("menekin", 11);

            //r.AddRecord("menekin", 9);



            //r.Print();
            Console.ReadKey();


            //menu.Render();

        }
    }
}
