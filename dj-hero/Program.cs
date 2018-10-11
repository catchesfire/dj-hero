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
            Audio.PrepareSongs();

            Audio.StartSong("main", true);
            Console.ReadKey();
            Console.WriteLine("Tutaj ktos zle wcisnal literke XD");
            Audio.Noise();
            Console.ReadKey();

            //menu.Render();

        }
    }
}
