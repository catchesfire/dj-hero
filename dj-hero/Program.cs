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
            Menu.Init();
            Audio a = new Audio();
            // a.Menu();
            a.PrepareSongs();

            //menu.Render();

        }
    }
}
