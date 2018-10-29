using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WMPLib;

namespace dj_hero
{
    public static class Audio
    {
        public static Song mainmenusong;
        public static Song noisesong;

        static readonly object locker = new object();

        private static List<Song> songs = new List<Song>();
        private static WMPLib.WindowsMediaPlayer Player = new WMPLib.WindowsMediaPlayer();
        private static WMPLib.WindowsMediaPlayer Player2= new WMPLib.WindowsMediaPlayer();
        public static readonly string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/DJH_MusicFiles";
        private static Thread t;

        // beep, gameover, invalid, lose, main, rank, selection, menu
        public static Dictionary<string, string> servicesTrack = new Dictionary<string, string>();


        public static void StartSong(Song song)
        {
                Player.URL = song.GetPath();
        }

        public static void StartServiceTrack(string key, bool isLoop = false)
        {
            t = new Thread(delegate ()
            {
                try
                {
                    Player2 = new WMPLib.WindowsMediaPlayer();
                    Player2.settings.volume = 60;
                    if (isLoop == true)
                        Player2.settings.setMode("loop", true);
                    else
                        Player2.settings.setMode("loop", false);
                    Player2.URL = servicesTrack[key];
                }
                catch { }

            });
            t.Start();



        }
        public static void StopTrack()
        {
            
            t.Abort();
            Player2.controls.stop();
        }


        public static void Noise()
        {
            Player.settings.volume = 50;
            StartSong(noisesong);

        }
        public static void StopSong()
        {
            Player.controls.stop();
        }

        public static void AddSongToList(Song s)
        {
            songs.Add(s);
        }

        public static int SetDurationSong(Song song)
        {
            WindowsMediaPlayer wmp = new WindowsMediaPlayer();
            string path = song.GetPath() ;
            IWMPMedia mediaInformation = wmp.newMedia(path);
            return (int)mediaInformation.duration;
        }

        public static void PrepareSongs()
        {
            Player.settings.volume = 20;
            //Player2.settings.volume = 80;

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
                string difficultyLevel;
                foreach (FileInfo fi in primaryDirectory.GetFiles())
                {
                    if (!File.Exists(Path.Combine(Audio.libraryPath, fi.Name)))
                        fi.CopyTo(Path.Combine(Audio.libraryPath, fi.Name), true);

                    difficultyLevel = fi.Name.Substring(fi.Name.Length - 5, 1);
                    if(Int32.TryParse(difficultyLevel,out int result))
                    {
                        Song s = new Song(fi.Name);
                        s.duration = SetDurationSong(s);
                        AddSongToList(s);
                    }
                    else
                    {
                        servicesTrack.Add(fi.Name.Substring(0, fi.Name.Length - 4), libraryPath + "/" + fi.Name);
                    }

                }
            }
        }




        public static List<Song> GetSongList() => songs.OrderBy(order => order.getDifficulty().GetOrder()).ToList();
    }
}