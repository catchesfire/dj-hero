using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dj_hero;
using WMPLib;
namespace dj_hero
{
    class Program
    {
        static void Main(string[] args)
        {
            Ascii.cat();
            Audio a = new Audio();
            a.Menu();
            ProgressBar p = new ProgressBar();
            p.ChangeStatus(50);

            Console.ReadKey();

        }
    }
}
