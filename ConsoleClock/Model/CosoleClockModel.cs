using System;
using System.Threading;
using ConsoleClock.Interface;

namespace ConsoleClock.Model
{
    public class ConsoleClockModel: IThreading, IPrinter
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public int Preview { get => 0; }
        public bool TimeSetted { get; set; }
        public Thread Clock { get; set; }

        public ConsoleClockModel()
        {
            DateTime Now = DateTime.Now;
            Hours = Now.Hour;
            Minutes = Now.Minute;
            Seconds = Now.Second;
            TimeSetted = true;
            Clock = new Thread(new ThreadStart(ClockWorker));
            Clock.Start();
        }

        private void ClockWorker()
        {

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

        public void Pause()
        {
            try
            {
                Clock.Suspend();
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
                Clock.Resume();
            }
            catch (ThreadStateException ex)
            {
                //Поток нельзя запустить, если он не остановлен
            }
        }
    }
}
