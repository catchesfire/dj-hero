using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_hero
{
    public class ViewElement
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public List<object> Lines { get; set; }

        public ViewElement(int _posX, int _posY, int _width, int _height, List<object> _lines)
        {
            PosX = _posX;
            PosY = _posY;
            Width = _width;
            Height = _height;
            Lines = _lines;
        }

        public void Update(List<object> lines)
        {
            //@ to do to check if line is different, if it is - reload
        }
    }
}
