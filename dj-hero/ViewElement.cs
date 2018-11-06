using Figgle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dj_hero
{
    public class ViewElement
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public ConsoleColor BackgroundColor { get; set; }
        public ConsoleColor ForegroundColor { get; set; }

        public List<string> Lines { get; set; }

        public static readonly object locker = new object();

        public ViewElement(int _posX, int _posY, int _width, int _height, List<string> _lines)
        {
            PosX = _posX;
            PosY = _posY;
            Width = _width;
            Height = _height;
            Lines = _lines;

            BackgroundColor = ConsoleColor.Black;
            ForegroundColor = ConsoleColor.White;
        }

        public void Clear()
        {
            if(PosX >= 0 && PosY >= 0)
            {
                for (int i = 0; i < Lines.Count; i++)
                {
                    string clear = "";
                    for(int j = 0; j < Width; j++)
                    {
                        clear += " ";
                    }
                    Console.SetCursorPosition(PosX, PosY + i);
                    Console.Write(clear);
                }
            }
        }

        public void ClearLine(int index)
        {
            for(int i = 0; i < Width; i++)
            {
                Console.SetCursorPosition(PosX + i, PosY + index);
                Console.Write(" ");
            }
        }

        public void Update()
        {
            Clear();
            if (PosX >= 0 && PosY >= 0)
            {
                Console.BackgroundColor = BackgroundColor;
                Console.ForegroundColor = ForegroundColor;
                for (int i = 0; i < Lines.Count; i++)
                {
                    string line;
                    if(Lines[i].Length >= Width)
                    {
                        line = Lines[i].Substring(0, Width);
                    }
                    else
                    {
                        line = Lines[i];
                    }
                    
                    Console.SetCursorPosition(PosX, PosY + i);
                    Console.Write(line);
                }

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void UpdateReverseColours()
        {
            ConsoleColor foreColor = ForegroundColor;
            ForegroundColor = BackgroundColor;
            BackgroundColor = foreColor;
            Update();
            foreColor = ForegroundColor;
            ForegroundColor = BackgroundColor;
            BackgroundColor = foreColor;
        }

        public void Update(int lineIndex, ConsoleColor colour = ConsoleColor.White)
        {
            ClearLine(lineIndex);
            Console.ForegroundColor = colour;
            Console.SetCursorPosition(PosX, PosY + lineIndex);
            Console.Write(Lines[lineIndex]);
            Console.ResetColor();
        }
    }
}
