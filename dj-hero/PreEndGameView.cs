using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_hero
{
    class PreEndGameView : View
    {
        GameView view;
        public PreEndGameView(GameView _view)
        {
            view = _view;
            Elements.Add("title", new ViewElement(10, 10, 10, 1, new List<string>() { "GAME OVER" }));
            base.Render();
            //base.Render();

        }
        private void wait()
        {
            Console.ReadKey();
        }
    }
}
