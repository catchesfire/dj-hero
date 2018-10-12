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
        public static List<Song> songs = new List<Song>();

        public static Song mainmenusong;
        public static Song noisesong;

        private string path;
        private string title;
        private Difficulty difficulty;

        public Song()
        {

        }

        public string GetPath() => path;

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

        public static void PrepareSongs()
        {
            string primaryPath = @"../../media";

            if (!Directory.Exists(primaryPath))
            {
                System.Environment.Exit(1);
                Console.WriteLine("Brak plików muzycznych. Gra odtwarzana bez muzyki.");
            }
            else
            {
                DirectoryInfo primaryDirectory = new DirectoryInfo(primaryPath);
                if (!Directory.Exists(Audio.libraryPath))
                {
                    Directory.CreateDirectory(Audio.libraryPath);
                }
                foreach (FileInfo fi in primaryDirectory.GetFiles())
                {
                    if (!File.Exists(Path.Combine(Audio.libraryPath, fi.Name)))
                        fi.CopyTo(Path.Combine(Audio.libraryPath, fi.Name), true);
                    if (fi.Name == "main.mp3")
                        mainmenusong = new Song(fi.Name);
                    else if (fi.Name == "noise.mp3")
                        noisesong = new Song(fi.Name);
                    else
                    {
                        Song s = new Song(fi.Name);
                        songs.Add(s);
                    }
                }
            }
        }

    }
}
