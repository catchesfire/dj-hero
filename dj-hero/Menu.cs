using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_hero
{
    public static class Menu
    {
        // switch to window difficult chose
        public static void Play()
        {
            //GameView gameView = new GameView();
            //gameView.Render();
            Game game = Game.Instance;
            game.play();
        }

        public static void Options()
        {

        }

        public static void Rank()
        {

        }

        public static void Exit()
        {
            System.Environment.Exit(1);
        }

    }
}
