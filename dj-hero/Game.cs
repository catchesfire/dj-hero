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

            Game.Instance.view.DisplayTime(time);


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

    public class ToChangeManager
    {
        private static ToChangeManager instance;
        public List<AppearingChar> items;

        private ToChangeManager()
        {
            items = new List<AppearingChar>();
        }

        public void Add(AppearingChar toChange)
        {
            if(items.Count == 3)
            {
                items.RemoveAt(0);
            }
            items.Add(toChange);
        }

        public static ToChangeManager GetInstance()
        {
            if(instance == null)
            {
                instance = new ToChangeManager();
            }

            return instance;
        }

    }

    public class ToChange
    {
        public int Id { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int ClicksNo { get; set; }
        public string Letter { get; set; }

        public ToChange()
        {
            PosX = -1;
            PosY = -1;
        }
    }



    public sealed class Game
    {
        public List<String> characterList = new List<string>();
        private GameTimer timer;
        public ConsoleKeyInfo pressedKey;
        private char current;
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

                    if (pressedKey.Key.ToString().ToUpper() == mainElement.character.ToString().ToUpper())
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
            view.DisplayProgressBar(progresBarValue);
            if (progresBarValue < 1)
            {
                EndGame();
            }
        }

        public void DecreaseProgresBarPerMiss()
        {
            progresBarValue -= matchOpttions.decPointsPerMiss;
            view.DisplayProgressBar(progresBarValue);
            if (progresBarValue < 1)
            {
                EndGame();
            }
        }

        public void IncreaseProgresBar()
        {
            progresBarValue += matchOpttions.incPointsPerSucceed;
            view.DisplayProgressBar(progresBarValue);
            if (progresBarValue > 100)
                progresBarValue = 100;
        }

        // --------------------------------------------------------------

        private void SuccesedClick()
        {
            // ++ points
            points += 10;
            view.DisplayPoints(points);
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

            //mainElement = new AppearingChar();
            //ToChangeManager.GetInstance().Add(mainElement);
            //view.RenderNewCharacter(mainElement);
            //view.Add(mainElement);
            //========================
            //3 posibility
            //first load
            if (mainElement == null)
            {
                

                for (int i=1; i<=matchOpttions.amountElementsSameTime;i++)
                {
                    mainElement = new AppearingChar();
                    queue.Enqueue(mainElement);
                    view.Add(mainElement);
                }
                mainElement = queue.Dequeue();


                return;
            }
            //refresh
            if (mainElement.counter > 0)
            {
                //view.refresh(mainElement);
                Console.WriteLine("no chance");
                //display 
            }
            //hit
            if (mainElement.counter == 0)
            {
                mainElement = new AppearingChar();
                queue.Enqueue(mainElement);
                view.Add(mainElement);

                mainElement = queue.Dequeue();

            }
            //=====================================


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
