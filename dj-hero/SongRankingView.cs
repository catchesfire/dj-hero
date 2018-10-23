using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_hero
{
    public class SongRankingView : View
    {
        public Song Song { get; internal set; }
        public List<Ranking.Score> PlayerList { get; internal set; }

        public SongRankingView(Song song)
        {
            Song = song;
            string h1 = "Im udało się uciec";
            string h2 = "To jest ranking dla " + Song.GetTitle();

            Elements.Add("H1", new ViewElement(Console.WindowWidth / 2 - h1.Length / 2, 3, h2.Length, 1, new List<string>() { h1 }));
            Elements.Add("H2", new ViewElement(5, 5, h2.Length, 1, new List<string>() { h2 }));

            string[] colHeaders = { "Lp.", "Name", "Score" };

            int colSize = (Console.WindowWidth / 3) - 5;

            for (int i = 0; i < 3; i++)
            {
                int x = (colSize * i) + (5 * i);
                Elements.Add("Table_col" + i + "_header", new ViewElement(x, 6, colSize, 1, new List<string>() { colHeaders[i] }));
            }

            for (int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    int x = (colSize * j) + (5 * j);
                    Elements.Add("Table_row" + i + "_col" + j, new ViewElement(x, 7 + i, colSize, 1, new List<string>() { "" }));
                }
            }
        }

        private void PrintScores()
        {
            for(int i = 0; i < PlayerList.Count; i++)
            {
                Elements["Table_row" + i + "_col0"].Lines[0] = (i + 1).ToString();
                Elements["Table_row" + i + "_col1"].Lines[0] = PlayerList[0].nickname;
                Elements["Table_row" + i + "_col2"].Lines[0] = PlayerList[0].points.ToString();
            }
        }

        public override void Render(bool clear = true)
        {
            PrintScores();
            base.Render(clear);

        }
    }
}
