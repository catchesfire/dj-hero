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

        public static List<string> logo = new List<string>()
               {
                    @"▓█████▄ ▄▄▄██▀▀▀    ██░ ██ ▓█████  ██▀███   ▒█████",
                    @"▒██▀ ██   ▒██      ▓██░ ██▒▓█   ▀ ▓██ ▒ ██▒▒██▒  ██▒",
                    @"░██   █   ░██      ▒██▀▀██░▒███   ▓██ ░▄█ ▒▒██░  ██▒",
                    @"░▓█▄   ▓██▄██▓     ░▓█ ░██ ▒▓█  ▄ ▒██▀▀█▄  ▒██   ██░",
                    @"░▒████▓ ▓███▒      ░▓█▒░██▓░▒████▒░██▓ ▒██▒░ ████▓▒░",
                    @" ▒▒▓  ▒ ▒▓▒▒░       ▒ ░░▒░▒░░ ▒░ ░░ ▒▓ ░▒▓░░ ▒░▒░▒░",
                    @" ░ ▒  ▒ ▒ ░▒░       ▒ ░▒░ ░ ░ ░  ░  ░▒ ░ ▒░  ░ ▒ ▒░",
                    @" ░ ░  ░ ░ ░ ░       ░  ░░ ░   ░     ░░   ░ ░ ░ ░ ▒",
                    @"   ░    ░   ░       ░  ░  ░   ░  ░   ░         ░ ░"
               };

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

            Ascii.Add("a", new List<string>()
            {
                @" █████╗ ",
                @"██╔══██╗",
                @"███████║",
                @"██╔══██║",
                @"██║  ██║",
                @"╚═╝  ╚═╝"
            });

            Ascii.Add("s", new List<string>()
            {
                @"███████╗",
                @"██╔════╝",
                @"███████╗",
                @"╚════██║",
                @"███████║",
                @"╚══════╝"
            });

            Ascii.Add("d", new List<string>()
            {
                @"██████╗ ",
                @"██╔══██╗",
                @"██║  ██║",
                @"██║  ██║",
                @"██████╔╝",
                @"╚═════╝"
            });

            Ascii.Add("j", new List<string>()
            {
                @"     ██╗",
                @"     ██║",
                @"     ██║",
                @"██   ██║",
                @"╚█████╔╝",
                @" ╚════╝ "
            });

            Ascii.Add("k", new List<string>()
            {
                @"██╗  ██╗",
                @"██║ ██╔╝",
                @"█████╔╝ ",
                @"██╔═██╗ ",
                @"██║  ██╗",
                @"╚═╝  ╚═╝"
            });

            Ascii.Add("l", new List<string>()
            {
                @"██╗     ",
                @"██║     ",
                @"██║     ",
                @"██║     ",
                @"███████╗",
                @"╚══════╝"
            });

            Ascii.Add("f", new List<string>()
            {
                @"███████╗",
                @"██╔════╝",
                @"█████╗  ",
                @"██╔══╝  ",
                @"██║     ",
                @"╚═╝     "
            });

            Ascii.Add("h", new List<string>()
            {
                @"██╗  ██╗",
                @"██║  ██║",
                @"███████║",
                @"██╔══██║",
                @"██║  ██║",
                @"╚═╝  ╚═╝"
            });

            Ascii.Add("z", new List<string>()
            {
                @"███████╗",
                @"╚══███╔╝",
                @"  ███╔╝ ",
                @" ███╔╝  ",
                @"███████╗",
                @"╚══════╝"
            });

            Ascii.Add("m", new List<string>()
            {
                @"███╗   ███╗",
                @"████╗ ████║",
                @"██╔████╔██║",
                @"██║╚██╔╝██║",
                @"██║ ╚═╝ ██║",
                @"╚═╝     ╚═╝"
            });

            Ascii.Add("q", new List<string>()
            {
                @" ██████╗ ",
                @"██╔═══██╗",
                @"██║   ██║",
                @"██║▄▄ ██║",
                @"╚██████╔╝",
                @" ╚══▀▀═╝ "
            });

            Ascii.Add("w", new List<string>()
            {
                @"██╗    ██╗",
                @"██║    ██║",
                @"██║ █╗ ██║",
                @"██║███╗██║",
                @"╚███╔███╔╝",
                @" ╚══╝╚══╝ "
            });

            Ascii.Add("e", new List<string>()
            {
                @"███████╗",
                @"██╔════╝",
                @"█████╗  ",
                @"██╔══╝  ",
                @"███████╗",
                @"╚══════╝"
            });

            Ascii.Add("r", new List<string>()
            {
                @"██████╗ ",
                @"██╔══██╗",
                @"██████╔╝",
                @"██╔══██╗",
                @"██║  ██║",
                @"╚═╝  ╚═╝"
            });

            Ascii.Add("u", new List<string>()
            {
                @"██╗   ██╗",
                @"██║   ██║",
                @"██║   ██║",
                @"██║   ██║",
                @"╚██████╔╝",
                @" ╚═════╝ "
            });

            Ascii.Add("i", new List<string>()
            {
                @"██╗",
                @"██║",
                @"██║",
                @"██║",
                @"██║",
                @"╚═╝"
            });

            Ascii.Add("o", new List<string>()
            {
                @" ██████╗ ",
                @"██╔═══██╗",
                @"██║   ██║",
                @"██║   ██║",
                @"╚██████╔╝",
                @" ╚═════╝ "
            });

            Ascii.Add("p", new List<string>()
            {
                @"██████╗ ",
                @"██╔══██╗",
                @"██████╔╝",
                @"██╔═══╝ ",
                @"██║     ",
                @"╚═╝     "
            });
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
