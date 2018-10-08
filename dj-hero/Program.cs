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
            
            Console.Write(FiggleFonts.Standard.Render("DJ Hero"));
            
            Audio a = new Audio();
             a.Menu();
            a.PrepareSongs();
            //  ProgressBar p = new ProgressBar();
            //  p.ChangeStatus(50);
            Console.WriteLine(Difficulty.easy.GetRandomCharacter());
            Console.ReadKey();
        }
    }
}
