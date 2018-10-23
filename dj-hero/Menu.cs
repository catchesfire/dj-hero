using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dj_hero
{
    public static class Menu
    {


        


        // switch to window difficult chose
        public static void Play()
        {
            NewGameView newGameView = new NewGameView();
            newGameView.Init();
        }

        public static void Options()
        {

        }

        public static void Rank()
        {
            RankingView rankingView = new RankingView();
        }

        public static void Exit()
        {
            System.Environment.Exit(1);
        }

    }
}
