using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_hero
{
    public class GameView : View
    {
        private ViewElement timer;
        private ViewElement progressBar;
        private ViewElement character;

        protected ViewElement points;

        public GameView()
        {
            timer = new ViewElement(Console.WindowWidth - 5, 1, 5, 3,
                new List<string>()
                {
                    "TIMER",
                    "",
                    "00:00"
                });
            progressBar = new ViewElement(3, 1, 20, 5, new List<string>());
            points = new ViewElement((Console.WindowWidth - 2) / 2, 1, 5, 1, new List<string>() { "0" });
            character = new ViewElement(Console.WindowWidth / 2, Console.WindowHeight / 2, 5, 1, new List<string>() { "" });
            Elements.Add("ProgressBar", progressBar);
            Elements.Add("Points", points);
            Elements.Add("Timer", timer);
            Elements.Add("Character", character);
        }

        public void DisplayTime(int time)
        {
            int minutes = time / 60;
            int seconds = time % 60;

            string sTime = minutes < 10 ? "0" + minutes.ToString() : minutes.ToString();
            sTime += ":";
            sTime += seconds < 10 ? "0" + seconds.ToString() : seconds.ToString();

            Elements["Timer"].Lines[2] = sTime;
            Elements["Timer"].Update(2);
        }

        public void DisplayPoints(int points)
        {
            Elements["Points"].Lines[0] = points.ToString();
            Elements["Points"].Update();
        }

        public void DisplayCharacter(string c)
        {
            Elements["Character"].Lines[0] = c;
            Elements["Character"].Update();
        }

        public void DisplayEndGame()
        {
            Console.Clear();
            Console.WriteLine("THATS IT! GAME OVER, MAN! GAME OVER! ");
        }
        
        public void DisplayAppearingCharacter(AppearingChar appChar)
        {
            Console.WriteLine("Character: "+appChar.character);
            Console.WriteLine("Counter:   "+appChar.counter);
        }
        private int counter = 0;
        public void Add(AppearingChar elem)
        {
            if (counter++ == 0)
                Console.Clear();
                Console.WriteLine(elem.character+ "    " + elem.counter);
            
            
        }
        public void refresh(AppearingChar elem)
        {
            Console.WriteLine("ref");
        }
    }
}
