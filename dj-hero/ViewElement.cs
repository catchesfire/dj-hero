using Figgle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_hero
{
    public class ViewElement
    {
        public static Dictionary<string, List<string>> Ascii;

        public int PosX { get; set; }
        public int PosY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public List<string> Lines { get; set; }

        static readonly object locker = new object();

        public ViewElement(int _posX, int _posY, int _width, int _height, List<string> _lines)
        {
            PosX = _posX;
            PosY = _posY;
            Width = _width;
            Height = _height;
            Lines = _lines;
        }

        public void Clear()
        {
            if(PosX >= 0 && PosY >= 0)
            {
                for (int i = 0; i < Lines.Count; i++)
                {
                    for(int j = 0; j < Width; j++)
                    {
                        Console.SetCursorPosition(PosX + j, PosY + i);
                        Console.Write(" ");
                    }
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
            //@ to do to check if line is different, if it is - reload
            lock (locker)
            {
                Clear();
                if(PosX >=0 && PosY >= 0)
                {
                    for (int i = 0; i < Lines.Count; i++)
                    {
                        Console.SetCursorPosition(PosX, PosY + i);
                        Console.Write(Lines[i]);
                    }
                }
            }
        }

        public void Update(ConsoleColor colour)
        {
            lock (locker)
            {
                Clear();
                if (PosX >= 0 && PosY >= 0)
                {
                    for (int i = 0; i < Lines.Count; i++)
                    {
                        Console.SetCursorPosition(PosX, PosY + i);
                        Console.ForegroundColor = colour;
                        Console.Write(Lines[i]);
                    }
                }
                Console.ResetColor();
            }
        }

        public void Update(int lineIndex)
        {
            ClearLine(lineIndex);
            Console.SetCursorPosition(PosX, PosY + lineIndex);
            Console.Write(Lines[lineIndex]);
        }
    }
}
