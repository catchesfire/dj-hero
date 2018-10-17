using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace dj_hero
{
    public static class Audio
    {
        private static List<Song> songs = new List<Song>();
        private static WMPLib.WindowsMediaPlayer Player = new WMPLib.WindowsMediaPlayer();
        private static WMPLib.WindowsMediaPlayer Player2 = new WMPLib.WindowsMediaPlayer();
        public static readonly string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/DJH_MusicFiles";


        public static void StartSong(Song song, bool isLoop = false)
        {
            if(isLoop == true)
                Player.settings.setMode("loop", true);
            else
                Player.settings.setMode("loop", false);
            if (song == Song.noisesong)
                Player2.URL = song.GetPath();
            else
                Player.URL = song.GetPath();
          
        }
        public static void Noise()
        {
            Player.settings.volume = 50;
            StartSong(Song.noisesong, true);
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

        public static List<Song> GetSongList() => songs;
    }
}