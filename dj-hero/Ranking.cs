using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_hero
{
    public class Ranking
    {
        private static readonly string rankingPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/DJH_MusicFiles/Ranking/";
        private ListSerializer<Score> XmlList;
        private readonly Song song;
        private List<Score> scores = new List<Score>();

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
            InitSerialize();
        }

        public void InitSerialize()
        {
            if (!Directory.Exists(rankingPath))
            {
                Directory.CreateDirectory(rankingPath);
            }

            var oc = new ObservableCollection<Score>();
            foreach (var item in scores)
                oc.Add(item);
            XmlList = new ListSerializer<Score>(rankingPath + song.GetTitle(), song.GetTitle() + ".xml", oc);
            XmlList.PullData();
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
            XmlList.PushData();
            return;
        }

        public void Print()
        {
            int i = 0;
            Console.WriteLine("Ranking dla {0}", song.GetTitle());
            if(scores.Count() == 0)
                Console.WriteLine("Ranking pusty, zagraj by być pierwszym!");
            else
                foreach (Score score in scores)
                {
                    Console.WriteLine("{0}. {1} - {2}", ++i, score.nickname, score.points);
                }
        }
    }
}
