using System;
using System.Collections.Generic;
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
        }

        public void StartSong() {
            Player.controls.play();
        }

        public void StopSong()
        {
            Player.controls.stop();
        }

        //song after entering mainmenu - set song and mode to loop
        public void Menu()
        {
            Player.URL = mainmenusong;
            Player.settings.setMode("loop", true);
            Player.controls.play();
        }

        //after eqiting mainmenu turn off loop & change song I guess xD
        public void QuitMenu()
        {
            Player.settings.setMode("loop", false);
            Player.controls.stop();
        }

    }
}
