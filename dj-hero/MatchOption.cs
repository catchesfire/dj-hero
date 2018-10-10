using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_hero
{
    public class MatchOption
    {
        public char[] charactersSet = Difficulty.easy.characters;
        public int answerTime = Difficulty.easy.answerTime;
        public int progresBarLosePerSec = 5;
        public int decPointsPerMiss = 15;
        public int incPointsPerSucceed = 10;
        public int maxBombCounterElement = 5;
        public int chanceBombElement =3  ;//range 0-10

        private MatchOption()
        {

        }

        private static MatchOption instance = new MatchOption();
        public static MatchOption Instance()
        {
            return instance;
        }
    }
}
