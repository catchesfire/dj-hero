using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_hero
{
    public class AppearingChar
    {
        public char character;
        public int counter;

        public AppearingChar()
        {
            Random rnd = new Random();
            MatchOption matchOption = MatchOption.Instance();
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
