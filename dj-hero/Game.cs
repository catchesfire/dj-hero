using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace dj_hero
{
    public class Element
    {
        private List<String> characterList = new List<string>();
        public string character;
        public Element()
        {
            characterList.Add("a");
            characterList.Add("b");
            characterList.Add("c");
            characterList.Add("d");
            characterList.Add("e");
            characterList.Add("f");
            characterList.Add("g");
            characterList.Add("h");
        }

        public string randomCharacter()
        {
            Random rnd = new Random();
            int no = rnd.Next() % 8;
            return characterList[no];
        }
    }

    public class GameTimer
    {
        private int time;
        
        private System.Timers.Timer timer = new System.Timers.Timer(1000);

        public GameTimer(int _time)
        {
            time = _time;
        }

        public void RunTimer()
        {
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
        }

        public void StopTimer()
        {
            timer.Stop();
            timer.Dispose();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            time--;

            // gameview odswierz widok(time);
            if(time == 0)
            {
                // go end game
                Game.Instance.EndGame();
                timer.Stop();
                timer.Dispose();
            }
            Game.Instance.TimeControler();
        }
    }




    public sealed class Game
    {
        public List<String> characterList = new List<string>();
        private GameTimer timer;
        public ConsoleKeyInfo pressedKey;
        private string current;
        Element elem;
        GameView view;
        private int points;
        
        private Boolean gameOver;

        private Game()
        {
           
        }

        private void init()
        {
            setTimeToAnswer(5);
            timer = new GameTimer(20);
            elem = new Element();
            view = new GameView();
            gameOver = false;


            //iterator = 0;
            //points = 0;

            var ts = new CancellationTokenSource();
            CancellationToken ct = ts.Token;
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    if (gameOver == true)
                    {
                        view.DisplayEndGame(); //<===
                        break;
                    }
                    pressedKey = Console.ReadKey(true);

                    if (pressedKey.Key.ToString().ToUpper() == current.ToUpper())
                    {
                        SuccesedClick();
                    }
                    else
                    {
                        MissClick();
                        
                    }
                    pressedKey = new ConsoleKeyInfo();

                    if (ct.IsCancellationRequested)
                    {
                        // another thread decided to cancel
                        break;
                    }
                }
            }, ct);

            
        }

        private void SuccesedClick()
        {
            // ++ points
            points += 10;
            // progres bar ++
            //load next segment
            LoadSegment();
        }

        private void MissClick()
        {
            // progresbar -- or nothing
            // load next segment
            LoadSegment();
        }

        private void LoadSegment()
        {
            //get costam level random character from marcin trash code
            // I HAVE NO IDEA WHAT KIND TYPE IT WILL RETURN

            current = elem.randomCharacter();
            view.DisplayCharacter(current);
            view.DisplayPoints(points);
            RefreshTimeToAnswer();
        }

        public void EndGame()
        {
            //Game view display stats and evrything
            gameOver = true;
            view.DisplayEndGame();
            view.DisplayPoints(points);
            //save to rank etc.

        }

        public void play()
        {
            init();
            timer.RunTimer();
            LoadSegment();
            
        }

        //clock stuff
        public void TimeControler()
        {
            timeToAnswer--;

            if (timeToAnswer==0)
            {
                MissClick(); //miss answer function
                timeToAnswer = 5;
            }
        }
        private int timeToAnswer;
        private int constTimeToAnsfer;

        private void RefreshTimeToAnswer()
        {
            timeToAnswer = constTimeToAnsfer;
        }
        public void setTimeToAnswer(int time)
        {
            constTimeToAnsfer = time;
            RefreshTimeToAnswer();
        }

        //singleton

        private static Game instance = new Game();
        public static Game Instance {
            get
            {
                return instance;
            }
        }

    }
}
