using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_hero
{
    class Audio
    {
        public static WMPLib.WindowsMediaPlayer Player = new WMPLib.WindowsMediaPlayer(); //player itself
        readonly static string mainmenusong = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DJH_MusicFiles", "cat.mp3"); //main menu song, to change
        readonly static string testSong = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DJH_MusicFiles", "testSong.mp3"); //main menu song, to change

        public Audio()
        {
            Player = new WMPLib.WindowsMediaPlayer();
            PrepareSongs();
        }

        public void StartSong() {
            Player.controls.play();
        }

        public static void StopSong()
        {
            Player.controls.stop();
        }

        //song after enter mainmenu - set song and mode to loop
        public void Menu()
        {
            Player.URL = mainmenusong;
            Player.settings.setMode("loop", true);
            Player.controls.play();
        }

        public static void TestSong()
        {
            Player.URL = testSong;
            Player.controls.play();
        }

        //after eqit mainmenu turn off loop & change song I guess xD
        public void QuitMenu()
        {
            Player.settings.setMode("loop", false);
            Player.controls.stop();
        }

       public void PrepareSongs()
        {
            string finalPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"/DJH_MusicFiles";
            string primaryPath = @"../../media";

            if (!Directory.Exists(primaryPath))
            {
                System.Environment.Exit(1);
                Console.WriteLine("Brak plików muzycznych. Gra odtwarzana bez muzyki.");
            }
            else
            {
                DirectoryInfo primaryDirectory = new DirectoryInfo(primaryPath); 
                if (!Directory.Exists(finalPath))
                {
                    Directory.CreateDirectory(finalPath);
                }
                foreach (FileInfo fi in primaryDirectory.GetFiles())
                {
                    if(!File.Exists(Path.Combine(finalPath, fi.Name)))
                        fi.CopyTo(Path.Combine(finalPath, fi.Name), true);
                }
            }

        }

    }
}
