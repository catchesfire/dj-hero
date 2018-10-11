using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_hero
{
    //Klasa audio jest niepubliczna, a jest managerem, cos nie bangla. Tak samo, czy potrzebujemy jej instancji skoro jest managerem?
    public static class Audio
    {
        private static WMPLib.WindowsMediaPlayer Player = new WMPLib.WindowsMediaPlayer();
        private static WMPLib.WindowsMediaPlayer Player2 = new WMPLib.WindowsMediaPlayer();
        private static Dictionary<string, string> SongPath= new Dictionary<string, string>();
        private static readonly string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/DJH_MusicFiles";

        public static void ReadDic()
        {
            foreach (var pair in SongPath)
            {
                Console.WriteLine("{0}, {1}", pair.Key, pair.Value);
            }
        }


        public static void StartSong(string title, bool isLoop)
        {
            if(isLoop == true)
                Player.settings.setMode("loop", true);
            else
                Player.settings.setMode("loop", false);
            Player.URL = title;
            Player.controls.play();
        }

        public static void Noise()
        {
            Player.settings.volume = 50;
            Player2.URL = noise;
            Player2.settings.setMode("loop", true);
            Player2.controls.play();
        }

        public static void StopSong()
        {
            Player.controls.stop();
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
                if (!Directory.Exists(libraryPath))
                {
                    Directory.CreateDirectory(libraryPath);
                }
                foreach (FileInfo fi in primaryDirectory.GetFiles())
                {
                    if (!File.Exists(Path.Combine(libraryPath, fi.Name)))
                        fi.CopyTo(Path.Combine(libraryPath, fi.Name), true);
                    GenerateSongName(fi.Name);

                }
            }
        }

        public static void GenerateSongName(string filename)
        {
            SongPath.Add(filename, filename.Substring(0, filename.Length - 4).Replace('_', ' '));
            return;
        }
    }
}