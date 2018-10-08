using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dj_hero
{
    public class MenuView : View
    {
        public int selectedOption = 0;
        ConsoleKeyInfo pressedKey;


        public void Display()
        {
            Console.WriteLine("LOGO");
            Console.WriteLine("1.Play");
            Console.WriteLine("2.Options");
            Console.WriteLine("3.rank");
            Console.WriteLine("4.Exit");

            var ts = new CancellationTokenSource();
            CancellationToken ct = ts.Token;
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    pressedKey = Console.ReadKey(true);

                    if (ct.IsCancellationRequested)
                    {
                        // another thread decided to cancel
                        break;
                    }
                }
            }, ct);

            while (true)
            {
                switch (pressedKey.Key)
                {
                    case ConsoleKey.D1:
                        ts.Cancel();
                        Menu.Play();
                        pressedKey = new ConsoleKeyInfo();
                        break;
                    case ConsoleKey.D2:
                        Menu.Options();
                        break;
                    case ConsoleKey.D3:
                        Menu.Rank();
                        break;
                    case ConsoleKey.D4:
                        Menu.Exit();
                        break;
                }
                
            }

        }
        
    }
}
