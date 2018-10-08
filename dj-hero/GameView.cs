using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_hero
{
    public class GameView
    {


        public void DisplayPoints(int points)
        {
            Console.WriteLine("Points: " +points);
        }

        public void DisplayCharacter(string c)
        {
            Console.Clear();
            Console.WriteLine("random element:  " + c);
        }

        public void DisplayEndGame()
        {
            Console.Clear();
            Console.WriteLine("THATS IT! GAME OVER, MAN! GAME OVER! ");
        }
    }
}
