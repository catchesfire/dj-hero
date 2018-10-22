using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_hero
{
    public class Song
    {




        private readonly string path;
        private readonly string title;
        private readonly Difficulty difficulty;

        public string getDifficultyName()
        {
            return difficulty.name;
        }
        public Difficulty getDifficulty()
        {
            return difficulty;
        }


        public int duration;

        public Song()
        {

        }

        public string GetPath() => path;
        public string GetTitle() => title;

        public Song(string filename)
        {
            path = Audio.libraryPath + "/" + filename;
            string difficultyLevel = filename.Substring(filename.Length - 5, 1);
            if (difficultyLevel == "1")
                difficulty = Difficulty.easy;
            else if (difficultyLevel == "2")
                difficulty = Difficulty.medium;
            else
                difficulty = Difficulty.hard;

            title = filename.Substring(0, filename.Length - 5).Replace('_', ' ');
        }

       

    }
}
