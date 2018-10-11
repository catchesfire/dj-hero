using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_hero
{
    //Nazywanie piosenek: JAK_MAM_TO_ZDAC.mp3 -> odtworzenie Audio.StartSong("jak mam to zdac", true/false)
    //Odtworzenie szumu Audio.Noise();
    public static class Audio
    {
        private static WMPLib.WindowsMediaPlayer Player = new WMPLib.WindowsMediaPlayer();
        private static WMPLib.WindowsMediaPlayer Player2 = new WMPLib.WindowsMediaPlayer();
        private static Dictionary<string, string> SongPath= new Dictionary<string, string>();
        private static readonly string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/DJH_MusicFiles";


        public static void StartSong(string title, bool isLoop)
        {
            if(isLoop == true)
                Player.settings.setMode("loop", true);
            else
                Player.settings.setMode("loop", false);

            if (SongPath.ContainsKey(title))
            {
                if(title == "noise")
                    Player2.URL = libraryPath + "/" + SongPath[title];
                else
                Player.URL = libraryPath + "/" + SongPath[title];

                Console.WriteLine(libraryPath + "/" + SongPath[title]);
            }
            else
            {
                Console.WriteLine("Internal Error 404 - Wybrana piosenka nie istnieje. Programista to ciolek XD");
            }
        }

        public static void Noise()
        {
            Player.settings.volume = 50;
            StartSong("noise", true);
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
            SongPath.Add(filename.Substring(0, filename.Length - 4).Replace('_', ' '), filename);
            return;
        }
    }
}