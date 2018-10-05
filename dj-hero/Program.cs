using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dj_hero;

namespace dj_hero
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgressBar a = new ProgressBar();
            a.ChangeStatus(-30);
            a.ChangeStatus(60);
            Console.ReadKey();
        }
    }
}
