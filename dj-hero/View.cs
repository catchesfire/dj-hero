using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_hero
{
    public class View
    {
        private int Width;
        private int Height;

        private List<ViewElement> elements;

        public List<ViewElement> Elements
        {
            get
            {
                return elements;
            }
            set
            {
                elements = value;
            }
        }

        public View()
        {
            elements = new List<ViewElement>();
            Width = Console.WindowWidth;
            Height = Console.WindowHeight;
        }

        public void AddElement(ViewElement element)
        {
            elements.Add(element);
        }

        private void Clear()
        {
            Console.Clear();
        }

        public virtual void Render()
        {
            Clear();
            foreach(var el in elements)
            {
                for(int  i = 0; i < el.Lines.Count; i++)
                {
                    Console.SetCursorPosition(el.PosX, el.PosY + i);
                    Console.Write(el.Lines[i]);
                }
            }
        }
    }
}
