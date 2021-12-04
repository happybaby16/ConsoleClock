using System;
using System.Collections.Generic;
using System.Threading;
using ConsoleClock.Interface;

namespace ConsoleClock.Model
{
    public class ConsoleStopwatchModel : IThreading, IPrinter
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public int Preview { get => 2; }
        public bool TimeSetted { get; set; }
        public int[] TimeSettered = new int[3];
        public Thread Stopwatch { get; set; }
        public ConsoleStopwatchModel()
        {
            TimeSetted = false;
            Hours = 1;
            Minutes = 0;
            Seconds = 0;
            Stopwatch = new Thread(new ThreadStart(StopwatchWorker));
            Stopwatch.Start();
        }
        private void StopwatchWorker()
        {
            Pause();
            while (true)
            {

                Seconds--;
                if (Seconds < -1)
                {
                    Seconds = 59;
                    Minutes--;
                }
                if (Minutes < -1)
                {
                    Minutes = 59;
                    Hours--;
                }
                if (Hours < -1)
                {
                    Hours = 0;
                }
                if (Seconds == 0 && Minutes == 0 && Hours == 0)
                {
                    Refresh();
                    Pause();
                }
                Thread.Sleep(1000);
            }
        }

        public void Refresh()
        {
            Hours = TimeSettered[0];
            Minutes = TimeSettered[1];
            Seconds = TimeSettered[2];
        }
        public void Exit()
        {
            Pause();
            Refresh();
            TimeSetted = false;
        }
        public void Pause()
        {
            try
            {
                Stopwatch.Suspend();
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
                Stopwatch.Resume();
            }
            catch (ThreadStateException ex)
            {
                //Поток нельзя запустить, если он не остановлен
            }
        }
    }
}
