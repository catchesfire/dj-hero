using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_hero
{
    public class View
    {
        //private int Width = Console.WindowWidth;
       // private int Height = Console.WindowHeight;

        public Dictionary<string, ViewElement> Elements { get; set; }

        public View()
        {
            Elements = new Dictionary<string, ViewElement>();
            //Width = Console.WindowWidth;
            //Height = Console.WindowHeight;

            
        }

        public void AddElement(string name, ViewElement element)
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
