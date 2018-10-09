using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_hero
{
    class ProgressBar
    {
        //usage of class : create bar as an object, change progress with ChangeStatus(number)

        private int fill = 50; // default progress of bar in percent
        private readonly int speedOfChange = 50; // rate of change of progress bar, measured in ms 
        public ProgressBar()
        {

        }

        //returns progress of bar in percent
        public int GetProgress()
        {
            return fill;
        }

        // returns progress of bar after change
        public int CountProgress(int difference)
        {
            if (fill + difference < 0)
                return 0;
            else if (fill + difference > 100)
                return 100;
            else
                return fill + difference;
        }

        // generates progress bar
        public void DisplayBar()
        {
            string ret = "[";
            for (int i = 0; i < 50; i++)
            {
                if (fill/2  > i)
                    ret = ret + "|";
                else
                    ret = ret + " ";
            }
            ret = ret + "]";
            if(fill<=30)
                Console.ForegroundColor = ConsoleColor.Red;
            else if(fill<=70)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else
                Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret);
            Console.ResetColor();
        }

        // operation of bar status change
        public void ChangeStatus(int difference)
        {
            int finalProgress = CountProgress(difference);
            if (difference > 0)
            {
                for (int i = fill; (difference > 0) ? i<=finalProgress : i>=finalProgress;  i++)
                {
                    UpdateStatus(i);
                }
            }
            else
            {
                for (int i = fill; i >= finalProgress; i--)
                {
                    UpdateStatus(i);
                }
            }
        }

        //animation of bar status change
        public void UpdateStatus(int iterator)
        {
            fill = iterator;
            Console.SetCursorPosition(0, 0);
            DisplayBar();
            System.Threading.Thread.Sleep(speedOfChange);
        }
    }
}
