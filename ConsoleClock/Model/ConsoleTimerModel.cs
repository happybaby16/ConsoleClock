using System;
using System.Threading;
using ConsoleClock.Interface;

namespace ConsoleClock.Model
{
    public class ConsoleTimerModel : IThreading, IPrinter
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public int Preview { get => 1; }
        public Thread Timer { get; set; }

        public ConsoleTimerModel()
        {
            Hours = 0;
            Minutes = 0;
            Seconds = 0;
            Timer = new Thread(new ThreadStart(TimerWorker));
            Timer.Start();
        }

        private void TimerWorker()
        {
            Pause();
            while (true)
            {

                Seconds++;
                if (Seconds > 60)
                {
                    Seconds = 0;
                    Minutes++;
                }
                if (Minutes > 60)
                {
                    Minutes = 0;
                    Hours++;
                }
                if (Hours > 24)
                {
                    Hours = 0;
                }
                Thread.Sleep(1000);
            }
        }

        public void Refresh()
        {
            Hours = 0;
            Minutes = 0;
            Seconds = 0;
        }
        public void Exit()
        {
            Pause();
            Refresh();
        }
        public void Pause()
        {
            try
            {
                Timer.Suspend();
            }
            catch (ThreadStateException ex)
            {
                //Поток нельзя остановить, если он уже остановлен
            }
        }
        public void Start()
        {
            try
            {
                Timer.Resume();
            }
            catch (ThreadStateException ex)
            {
                //Поток нельзя запустить, если он не остановлен
            }
        }


    }
}
