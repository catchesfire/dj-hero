using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_hero
{
    public class AppearingChar
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        public char character;
        public int counter;

        public AppearingChar(MatchOption matchOption)
        {
            PosX = -1;
            PosY = -1;
            Random rnd = new Random();
            
            int len = matchOption.charactersSet.Length;
            character = matchOption.charactersSet[rnd.Next(len)];

            if(matchOption.chanceBombElement != 0)
            {
                if (rnd.Next(10) < matchOption.chanceBombElement)
                    counter = rnd.Next(matchOption.maxBombCounterElement) + 1;
                else
                    counter = 1;
            }
            else
            {
                counter = 1;
            }
        }
    }
}
