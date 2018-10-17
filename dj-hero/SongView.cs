using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_hero
{
    public class SongView : View
    {
        private int x, y;

        private Song song;

        public void SetTick()
        {

            Elements["tick"] = new ViewElement(x, y, 1, 4, new List<string>()
                {
                    @" ",
                    @"\",
                    @"/",
                    @" "
                });
            Elements["tick"].Update();
        }
        public void RemoveTick()
        {
            Elements["tick"] = new ViewElement(x, y, 1, 4, new List<string>()
                {
                    @" ",
                    @" ",
                    @" ",
                    @" "
                });
            Elements["tick"].Update();
        }



        public SongView(int _x, int _y, Song _song)
        {
            x = _x;
            y = _y;
            song = _song;

            Elements.Add("tick", new ViewElement(x, y, 1, 4, new List<string>()
                {
                    @" ",
                    @" ",
                    @" ",
                    @" "
                }));

            Elements.Add("ramka", new ViewElement(x+1, y, 40,7, new List<string>()
                {
                    @"╔═════════════════════════════════════╗",
                    @"║                                     ║",
                    @"║                                     ║",
                    @"╚═════════════════════════════════════╝"
                }));
            Elements.Add("title", new ViewElement(x+2, y+1, 38, 1, new List<string>() { song.GetTitle() }));

            int minutes = song.duration / 60;
            int seconds = song.duration % 60;

            string sTime = minutes < 10 ? "0" + minutes.ToString() : minutes.ToString();
            sTime += ":";
            sTime += seconds < 10 ? "0" + seconds.ToString() : seconds.ToString();

            Elements.Add("time", new ViewElement(x+2, y+2, 5, 1, new List<string>() { sTime }));
            
            Elements.Add("difficulty", new ViewElement(x + 11, y + 2, 8, 1, new List<string>() { song.getDifficultyName() }));
            








        }
    }
}
