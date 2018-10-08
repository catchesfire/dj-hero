using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_hero
{
    public class Difficulty
    {
        private readonly char[] characters;
        private readonly int answerTime;

        public int getAnswerTime()
        {
            return answerTime;
        }

        private static readonly char[] easyCharacters = { 'a', 's', 'd', 'j', 'k', 'l'};
        private static readonly char[] mediumCharacters = { 'a', 's', 'd', 'f', 'h', 'j', 'k', 'l', 'z', 'm'};
        private static readonly char[] hardCharacters = { 'a', 's', 'd', 'f', 'h', 'j', 'k', 'l', 'z', 'm', 'q', 'w', 'e', 'r', 'u', 'i', 'o', 'p'};


        public Difficulty(char[] _characters, int _answerTime)
        {
            this.characters = _characters;
            this.answerTime = _answerTime;
        }

        public static Difficulty easy = new Difficulty(easyCharacters, 5);
        public static Difficulty medium = new Difficulty(mediumCharacters, 4);
        public static Difficulty hard = new Difficulty(hardCharacters, 3);


        public char GetRandomCharacter()
        {
            Random rand = new Random();
            return characters[rand.Next(characters.Length)];
        }
    }
}
