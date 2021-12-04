using System;
using System.Collections.Generic;
using System.Threading;
using ConsoleClock.Interface;
using ConsoleClock.Model.State;

namespace ConsoleClock.Model
{
    public class MenuModel: IThreading
    {
        public ConsoleClockModel MyClock { get; set; }
        public ConsoleTimerModel MyTimer { get; set; }
        public ConsoleStopwatchModel MyStopwatch { get; set; }
        public Thread Menu { get; set; }
        public MenuModel(ConsoleClockModel _Clock, ConsoleTimerModel _Timer = null, ConsoleStopwatchModel _Stopwatch = null)
        {   
            MyClock = _Clock;
            MyTimer = _Timer;
            MyStopwatch = _Stopwatch;
            States.State = (int)States.CollectionStates.Clock;//Объявление начального статуса часов
            Menu = new Thread(new ThreadStart(MenuWorker));
            Menu.Start();
        }

        private void MenuWorker()
        {
            while (true)
            {
                char Key = Console.ReadKey().KeyChar;
                switch (Key)
                {
                    case '1':
                        //Проверка состояния (режим работы)
                        switch (States.State)
                        {
                            case 0:
                                MyClock.Pause();
                                break;
                            case 1:
                                MyTimer.Pause();
                                break;
                            case 2:
                                MyStopwatch.Pause();
                                break;
                        }
                        break;
                    case '2':
                        //Проверка состояния (режим работы)
                        switch (States.State)
                        {
                            case 0:
                                MyClock.Start();
                                break;
                            case 1:
                                MyTimer.Start();
                                break;
                            case 2:
                                MyStopwatch.Start();
                                break;
                        }
                        break;
                    case '3':
                        switch (States.State)
                        {
                            case 0:
                                States.State = (int)States.CollectionStates.Timer;
                                break;
                            case 1:
                                MyTimer.Refresh();
                                break;
                            case 2:
                                MyStopwatch.Refresh();
                                break;
                        }
                        break;
                    case '4':
                        switch (States.State)
                        {
                            case 0:
                                States.State = (int)States.CollectionStates.Stopwatch;
                                break;
                        }
                        break;
                    case '5':
                        MyClock.TimeSetted = false;
                        break;
                    case '0':
                        States.State = (int)States.CollectionStates.Clock;
                        MyTimer.Exit();
                        MyStopwatch.Exit();
                        break;
                }
            }
        }
        public void Pause()
        {
            try
            {
                Menu.Suspend();
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
                Menu.Resume();
            }
            catch (ThreadStateException ex)
            {
                //Поток нельзя запустить, если он не остановлен
            }
        }
    }
}
