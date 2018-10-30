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
        public int progresBarValue = 100;
        public int progresBarLosePerSec = 10;
        public int decPointsPerMiss = 20;
        public int incPointsPerSucceed = 15;
        public int maxBombCounterElement = 4;
        public int chanceBombElement =8  ;//range 0-10
        public int amountElementsSameTime = 3;
        public string nickname = "Player";

        public MatchOption()
        {

        }

        public MatchOption(Song song)
        {
            charactersSet = song.getDifficulty().characters;
            answerTime = song.getDifficulty().answerTime;
        }


    }
}
