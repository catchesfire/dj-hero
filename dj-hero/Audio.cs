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
        WMPLib.WindowsMediaPlayer Player; //player itself
        readonly static string mainmenusong = @"C:\Users\Marcin\source\repos\dj-hero\dj-hero\bin\Debug\media\cat.mp3"; //main menu song, to change

        public Audio()
        {
            Player = new WMPLib.WindowsMediaPlayer();
            PrepareSongs();
        }

        public void StartSong() {
            Player.controls.play();
        }

        public void StopSong()
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

        //after eqit mainmenu turn off loop & change song I guess xD
        public void QuitMenu()
        {
            Player.settings.setMode("loop", false);
            Player.controls.stop();
        }

       public void PrepareSongs()
        {
            string finalPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"/DJH_MusicFiles";
            string primaryPath = @"./media";

            if (!Directory.Exists(primaryPath))
            {
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
                    fi.CopyTo(Path.Combine(finalPath, fi.Name), true);
                }
            }

        }

    }
}
