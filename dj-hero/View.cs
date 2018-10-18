using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_hero
{
    public abstract class View
    {

        protected int width;
        protected int height;
        protected int posX;
        protected int posY;


        public Dictionary<string, ViewElement> Elements { get; set; }

        public View()
        {
            Elements = new Dictionary<string, ViewElement>();

            width = Console.WindowWidth;
            height = Console.WindowHeight;

            
        }

        public virtual void AddElement(string name, ViewElement element)
        {
            Elements.Add(name, element);
        }

        public void Clear()
        {
            Console.Clear();
        }

        public virtual void Render(bool clear = true)
        {
            if(clear)
                Clear();
            foreach (KeyValuePair<string, ViewElement> element in Elements)
            {
                if(element.Value.PosX >= 0 && element.Value.PosY >= 0)
                {
                    for(int i = 0; i < element.Value.Lines.Count; i++)
                    {
                        Console.SetCursorPosition(element.Value.PosX, element.Value.PosY + i);
                        Console.Write(element.Value.Lines[i]);
                    }
                }
                // do something with entry.Value or entry.Key
            }
        }
    }
}
