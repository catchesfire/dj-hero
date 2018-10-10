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
        private ViewElement character0;
        private ViewElement character1;
        private ViewElement character2;

        private int characterIndex;

        protected ViewElement points;

        public GameView()
        {
            characterIndex = 0;
            timer = new ViewElement(Console.WindowWidth - 5, 1, 5, 3,
                new List<string>()
                {
                    "TIMER",
                    "",
                    "00:00"
                });
            progressBar = new ViewElement(3, 1, 20, 5, new List<string>() { "" });
            points = new ViewElement((Console.WindowWidth - 2) / 2, 1, 5, 1, new List<string>() { "0" });
            character0 = new ViewElement(Console.WindowWidth / 2, Console.WindowHeight / 2, 5, 1, new List<string>() { ""});
            character1 = new ViewElement(Console.WindowWidth / 2, (Console.WindowHeight / 2) + 1, 5, 1, new List<string>() { ""});
            character2 = new ViewElement(Console.WindowWidth / 2, (Console.WindowHeight / 2) + 2, 5, 1, new List<string>() { ""});
            Elements.Add("ProgressBar", progressBar);
            Elements.Add("Points", points);
            Elements.Add("Timer", timer);
            Elements.Add("Character0", character0);
            Elements.Add("Character1", character1);
            Elements.Add("Character2", character2);
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

        public void DisplayProgressBar(int percent)
        {
            Elements["ProgressBar"].Lines[0] = percent.ToString();
            Elements["ProgressBar"].Update();
        }

        public void DisplayPoints(int points)
        {
            Elements["Points"].Lines[0] = points.ToString();
            Elements["Points"].Update();
        }

        public void DisplayCharacter(string c)
        {
 
        }

        public void RenderNewCharacter(ToChange character)
        {
            character.Id = characterIndex;
            Random rand = new Random();
            character.PosX = rand.Next(0, 118);
            character.PosY = rand.Next(10, 29);
            Elements["Character" + characterIndex % 3].Clear();
            Elements["Character" + characterIndex % 3].PosX = character.PosX;
            Elements["Character" + characterIndex % 3].PosY = character.PosY;
            Elements["Character" + characterIndex % 3].Lines[0] = character.Letter + character.ClicksNo.ToString();
            Elements["Character" + characterIndex % 3].Update();
            characterIndex++;
        }

        public void UpdateCharacter()
        {
            ToChange character = ToChangeManager.GetInstance().items[0];
            if (character.ClicksNo == 0)
            {
                Elements["Character" + character.Id % 3].Clear();
            }
            else
            {
                Elements["Character" + character.Id % 3].Lines[0] = character.Letter + character.ClicksNo.ToString();
                Elements["Character" + characterIndex % 3].Update();
            }
        }

        public void DisplayEndGame()
        {
            Console.Clear();
            Console.WriteLine("THATS IT! GAME OVER, MAN! GAME OVER! ");
        }
    }
}
