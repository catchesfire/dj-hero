using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_hero
{
    public class GameView : View
    {
        public override void Render()
        {
            Elements.Add(new ViewElement(15, 20, 15, 7, new List<object>() { @"              ,", @"            /'/", @"          /' / ", @"       ,/'  /", @"      /`--,/", @"    /'    /", @"(,/'     (_, " }));
            base.Render();
        }
    }
}
