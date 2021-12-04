using System;
using System.Threading;
using ConsoleClock.Model;
using ConsoleClock.Model.State;
using ConsoleClock.ViewModel;
using ConsoleClock.Interface;


namespace ConsoleClock
{
    partial class Program
    {
        static MenuModel Menu;

        static IPrinter ObjectPrint;//Интерфейс, который говорит, что и как отрисовать
        static Thread ThreadPrinter;//Поток отвечающий за всю отрисовку

        static ConsoleClockModel Clock; //Объект класса с часами
        static ConsoleTimerModel Timer; //Объект класса с таймером
        static ConsoleStopwatchModel Stopwatch; //Объект класса с секундомером

        static void Main(string[] args)
        {
            Clock = new ConsoleClockModel();
            Timer = new ConsoleTimerModel();
            Stopwatch = new ConsoleStopwatchModel();

            States.State = (int)States.CollectionStates.Clock;
            ObjectPrint = Clock;

            Thread ThreadObjectPrintChanger = new Thread(new ThreadStart(delegate () { ObjectPrintChanger(); }));
            ThreadObjectPrintChanger.Start();

            Menu = new MenuModel(Clock, Timer, Stopwatch);

            ThreadPrinter = new Thread(new ThreadStart(delegate () { Printer(); }));
            ThreadPrinter.Start();

        }
    }
}
