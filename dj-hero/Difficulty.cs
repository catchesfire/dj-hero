using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_hero
{
    public class Difficulty
    {
        //private readonly char[] characters;
        //private readonly int answerTime;
        private int order;
        public char[] characters;
        public int answerTime;
        public string name;

        public int getAnswerTime()
        {
            return answerTime;
        }

        public int GetOrder()
        {
            return order;
        }

        private static readonly char[] easyCharacters = { 'a', 's', 'd', 'j', 'k', 'l'};
        private static readonly char[] mediumCharacters = { 'a', 's', 'd', 'f', 'h', 'j', 'k', 'l', 'z', 'm'};
        private static readonly char[] hardCharacters = { 'a', 's', 'd', 'f', 'h', 'j', 'k', 'l', 'z', 'm', 'q', 'w', 'e', 'r', 'u', 'i', 'o', 'p'};


        public Difficulty(int _order, char[] _characters, int _answerTime, string _name)
        {
            order = _order;
            this.characters = _characters;
            this.answerTime = _answerTime;
            this.name = _name;
        }

        public static Difficulty easy = new Difficulty(1,easyCharacters, 5, "easy");
        public static Difficulty medium = new Difficulty(2,mediumCharacters, 4, "medium");
        public static Difficulty hard = new Difficulty(3,hardCharacters, 3, "hard");


        public char GetRandomCharacter()
        {
            Random rand = new Random();
            return characters[rand.Next(characters.Length)];
        }
    }
}
