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
        protected Dictionary<string, List<string>> Ascii { get; set; }

        public View()
        {
            Elements = new Dictionary<string, ViewElement>();
            Ascii = new Dictionary<string, List<string>>();
            width = Console.WindowWidth;
            height = Console.WindowHeight;

            Ascii.Add("0", new List<string>()
            {
                @"  ___ ",
                @" / _ \",
                @"| | | |",
                @"| | | |",
                @" \___/"
            });

            Ascii.Add("1", new List<string>()
            {
                @" _",
                @"/ |",
                @"| |",
                @"| |",
                @"|_|",
            });

            Ascii.Add("2", new List<string>()
            {
                @" ____",
                @"|___ \",
                @"  __) |",
                @" / __/",
                @"|_____|"
            });

            Ascii.Add("3", new List<string>()
            {
                @" _____",
                @"|___ /",
                @"  |_ \",
                @" ___) |",
                @"|____/",
            });

            Ascii.Add("4", new List<string>()
            {
                @" _  _",
                @"| || |",
                @"| || |_",
                @"|__   _|",
                @"   |_|",
            });

            Ascii.Add("5", new List<string>()
            {
                @" ____",
                @"| ___|",
                @"|___ \",
                @" ___) |",
                @"|____/",
            });

            Ascii.Add("6", new List<string>()
            {
                @"  __",
                @" / /_",
                @"| '_ \",
                @"| (_) |",
                @" \___/",
            });

            Ascii.Add("7", new List<string>()
            {
                @" _____",
                @"|___  |",
                @"   / /",
                @"  / /",
                @" /_/",
            });

            Ascii.Add("8", new List<string>()
            {
                @"  ___",
                @" ( _ )",
                @" / _ \",
                @"| (_) |",
                @" \___/",
            });

            Ascii.Add("9", new List<string>()
            {
                @"  ___",
                @" / _ \",
                @"| (_) |",
                @" \__, |",
                @"   /_/",
            });

            //Ascii.Add("a", new List<string>()
            //{
            //    @"    _",
            //    @"   / \",
            //    @"  / _ \",
            //    @" / ___ \",
            //    @"/_/   \_\",
            //});

            Ascii.Add("a", new List<string>()
            {
                @" █████╗",
                @"██╔══██╗",
                @"███████║",
                @"██╔══██║",
                @"██║  ██║",
                @"╚═╝  ╚═╝"
            });

            Ascii.Add("s", new List<string>()
            {
                @" ____",
                @"/ ___|",
                @"\___ \",
                @" ___) |",
                @"|____/",

            });

            Ascii.Add("d", new List<string>()
            {
                @" ____",
                @"|  _ \",
                @"| | | |",
                @"| | | |",
                @"|____/",
            });

            Ascii.Add("j", new List<string>()
            {
                @"     _",
                @"    | |",
                @" _  | |",
                @"| |_| |",
                @" \___/",
            });

            Ascii.Add("k", new List<string>()
            {
                @" _  __",
                @"| |/ /",
                @"| ' /",
                @"| . \",
                @"|_|\_\",
            });

            Ascii.Add("l", new List<string>()
            {
                @" _ ",
                @"| |",
                @"| |",
                @"| |___",
                @"|_____|",
            });
        }

        public virtual void AddElement(string name, ViewElement element)
        {
            Elements.Add(name, element);
        }

        public void Clear()
        {
            Console.Clear();
        }

        public virtual void Render()
        {
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
