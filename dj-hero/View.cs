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
        public static List<string> logo = new List<string>()
               {
                    @"______  ___   _   _  ___________ _____",
                    @"|  _  \|_  | | | | ||  ___| ___ \  _  |",
                    @"| | | |  | | | |_| || |__ | |_/ / | | |",
                    @"| | | |  | | |  _  ||  __||    /| | | |",
                    @"| |/ /\__/ / | | | || |___| |\ \\ \_/ /",
                    @"|___/\____/  \_| |_/\____/\_| \_|\___/"
               };

        public View()
        {
            Elements = new Dictionary<string, ViewElement>();

            width = Console.WindowWidth;
            height = Console.WindowHeight;

        }

        public List<string> DrawRect(int width, int height)
        {
            List<string> rect = new List<string>();
            string leftTopCorner = "╔";
            string leftBottomCorner = "╚";
            string rightTopCorner = "╗";
            string rightBottomCorner = "╝";
            string vertical = "║";
            string horizontal = "═";

            for(int i = 0; i < height; i++)
            {
                string line = "";

                if (i == 0)
                {
                    line += leftTopCorner;
                }
                else if(i == height - 1)
                {
                    line += leftBottomCorner;
                }
                else
                {
                    line += vertical;
                }

                for(int j = 1; j < width - 2; j++)
                {
                    if(i == 0 || i == height - 1)
                    {
                        line += horizontal;
                    }
                    else
                    {
                        line += " ";
                    }
                }

                if(i == 0)
                {
                    line += rightTopCorner;
                } else if(i == height - 1)
                {
                    line += rightBottomCorner;
                }
                else
                {
                    line += vertical;
                }


                rect.Add(line);

            }

            return rect;
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
                element.Value.Update();
            }
        }
    }
}
