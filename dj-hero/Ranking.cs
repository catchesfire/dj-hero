using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_hero
{
    public class Ranking
    {
        private readonly Song song;
        private List<Score> scores = new List<Score>();

        public Ranking()
        {

        }

        public struct Score
        {
            public string nickname;
            public int points;

            public Score(string _nickname, int _points)
            {
                nickname = _nickname;
                points = _points;
            }
        }

        public Ranking(Song _song)
        {
            song = _song;
        }

        public void AddRecord(string playerName, int playerScore)
        {
            Score s = new Score(playerName, playerScore);
            scores.Add(s);
            scores = scores.OrderByDescending(o => o.points).ToList();

            if (scores.Count() > 10)
            {
                scores.RemoveAt(scores.Count - 1);
            }
            return;
        }

        public void Print()
        {
            int i = 0;
            Console.WriteLine("Ranking dla {0}", song.GetTitle());
            foreach (Score score in scores)
            {
                Console.WriteLine("{0}. {1} - {2}", ++i, score.nickname, score.points);
            }
        }




    }
}
