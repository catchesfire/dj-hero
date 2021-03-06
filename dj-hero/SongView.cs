﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_hero
{
    public class SongView : View
    {
        private int x, y;

        public Song song;

        public void SetTick()
        {

            Elements["tick"] = new ViewElement(x, y, 1, 4, new List<string>()
                {
                    @" ",
                    @"\",
                    @"/",
                    @" "
                });
            Elements["tick"].Update();
        }
        public void RemoveTick()
        {
            Elements["tick"].Clear();
        }

        public SongView(int _x, int _y, int _width, Song _song)
        {
            x = _x;
            y = _y;
            width = _width;
            song = _song;

            Elements.Add("tick", new ViewElement(x, y, 1, 4, new List<string>()
                {
                    @" ",
                    @" ",
                    @" ",
                    @" "
                }));

            Elements.Add("ramka", new ViewElement(x + 1, y, width - 2, 4, DrawRect(width - 2, 4)));
            Elements.Add("title", new ViewElement(x + 2, y+1, width - 6, 1, new List<string>() { song.GetTitle() }));

            int minutes = song.duration / 60;
            int seconds = song.duration % 60;

            string sTime = minutes < 10 ? "0" + minutes.ToString() : minutes.ToString();
            sTime += ":";
            sTime += seconds < 10 ? "0" + seconds.ToString() : seconds.ToString();

            Elements.Add("time", new ViewElement(x+2, y+2, 5, 1, new List<string>() { sTime }));

            string difficulty = "Difficulty: " + song.getDifficultyName();

            Elements.Add("Difficulty_label", new ViewElement(x + width - difficulty.Length - 4, y + 2, 11, 1, new List<string>() { "Trudność:" }));
            Elements.Add("Difficulty", new ViewElement(Elements["Difficulty_label"].PosX + 10, y + 2, difficulty.Length - 9, 1, new List<string>() { song.getDifficultyName() }));

            ConsoleColor color;
            switch (Elements["Difficulty"].Lines[0])
            {
                case "łatwy":
                    color = ConsoleColor.Green;
                    break;
                case "średni":
                    color = ConsoleColor.DarkYellow;
                    break;
                case "trudny":
                    color = ConsoleColor.DarkRed;
                    break;
                default:
                    color = ConsoleColor.White;
                    break;
            }

            Elements["Difficulty"].ForegroundColor = color;

        }
    }
}
