using System;
using System.Collections.Generic;
using System.IO;
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

            //Game.Instance.view.DisplayTime(time);

            if(time == 0)
            {
                // go end game
                Game.Instance.EndGame();
                timer.Stop();
                timer.Dispose();
            }
            else
            {
                Game.Instance.DecreaseProgresBarPerSec();
                Game.Instance.TimeControler();
            }
        }
    }




    public sealed class Game
    {
        public List<String> characterList = new List<string>();
        private GameTimer timer;
        public ConsoleKeyInfo pressedKey;
        private char current;
        Element elem;
        public GameView view;
        private int points;
        private int progresBarValue;
        MatchOption matchOpttions = MatchOption.Instance();

        private Boolean gameOver;

        private Game()
        {
           
        }

        private void init()
        {
            
            Audio.TestSong();


            points = 0;
            progresBarValue = 100;

            timer = new GameTimer(20);

            elem = new Element();
            view = new GameView();
            view.Render();
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

                    if (pressedKey.Key.ToString().ToUpper() == current.ToString().ToUpper())
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
        // -- operation on progresbarr

        public void DecreaseProgresBarPerSec()
        {
            progresBarValue -= matchOpttions.progresBarLosePerSec;
            if(progresBarValue < 1)
            {
                EndGame();
            }
        }

        public void DecreaseProgresBarPerMiss()
        {
            progresBarValue -= matchOpttions.decPointsPerMiss;
            if (progresBarValue < 1)
            {
                EndGame();
            }
        }

        public void IncreaseProgresBar()
        {
            progresBarValue += matchOpttions.incPointsPerSucceed;
            if (progresBarValue > 100)
                progresBarValue = 100;
        }

        // --------------------------------------------------------------

        private void SuccesedClick()
        {
            // ++ points
            points += 10;
            // progres bar ++
            IncreaseProgresBar();
            //load next segment
            mainElement.counter--;
            LoadSegment();
        }

        private void MissClick()
        {
            // progresbar -- or nothing
            DecreaseProgresBarPerMiss();
            // load next segment
            mainElement.counter = 0;
            LoadSegment();
        }

        private AppearingChar mainElement;
        private Queue<AppearingChar> queue = new Queue<AppearingChar>();
        private void LoadSegment()
        {
            //core
            RefreshTimeToAnswer();

            mainElement = new AppearingChar();
            view.Add(mainElement);
            //3 posibility
            //first load
            //if(mainElement == null)
            //{
            //    mainElement = new AppearingChar();
            //    queue.Enqueue(mainElement);
            //    view.Add(mainElement);
            //    mainElement = new AppearingChar();
            //    queue.Enqueue(mainElement);
            //    view.Add(mainElement);

            //    mainElement = new AppearingChar();
            //    current = mainElement.character;
            //    view.Add(mainElement);

            //    return;
            //}
            ////refresh
            //if(mainElement.counter>0)
            //{
            //    view.refresh(mainElement);
            //    //display 
            //}
            ////hit
            //if(mainElement.counter==0)
            //{
            //    mainElement = new AppearingChar();
            //    queue.Enqueue(mainElement);
            //    view.Add(mainElement);

            //    mainElement = queue.Dequeue();

            //}


        }

        public void EndGame()
        {
            //Game view display stats and evrything
            gameOver = true;
            Audio.StopSong();
            view.DisplayEndGame();
            view.DisplayPoints(points);
            //save to rank etc.

        }

        public void play()
        {
            init();
            timer.RunTimer();
            LoadSegment();
            while(!gameOver)
            {

            }
            Console.ReadKey();
        }

        //clock stuff
        public void TimeControler()
        {
            timeToAnswer--;

            if (timeToAnswer==0)
            {
                MissClick(); //miss answer function
                timeToAnswer = matchOpttions.answerTime;
            }
        }
        private int timeToAnswer;

        private void RefreshTimeToAnswer()
        {
            timeToAnswer = matchOpttions.answerTime;
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
