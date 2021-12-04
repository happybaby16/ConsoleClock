using System;
using System.Threading;
using ConsoleClock.Model.State;
using ConsoleClock.ViewModel;
using ConsoleClock.Interface;
using System.Collections.Generic;

namespace ConsoleClock
{
    partial class Program
    {

        static void Printer()
        {
            while (true)
            {
                PrintClock.Clear();
                PrintClock.Print(ObjectPrint);
                Thread.Sleep(1000);
            }
        }

        static void ObjectPrintChanger()
        {
            while (true)
            {
                switch (States.State)
                {
                    case 0:
                        if (!Clock.TimeSetted) SetTime();
                        ObjectPrint = Clock;
                        break;
                    case 1:
                        ObjectPrint = Timer;
                        break;
                    case 2:
                        if (!Stopwatch.TimeSetted) SetTime();
                        ObjectPrint = Stopwatch;
                        break;
                }
            }
        }


        static void SetTime()
        {
            Menu.Pause();
            ThreadPrinter.Suspend();
            switch (States.State)
            {
                case 0:
                    Console.Clear();
                    Console.Write("Введите количество часов: ");
                    Clock.Hours = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\nВведите количество минут: ");
                    Clock.Minutes = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\nВведите количество секунд: ");
                    Clock.Seconds = Convert.ToInt32(Console.ReadLine());
                    Clock.TimeSetted = true;
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Введите количество часов: ");
                    Stopwatch.Hours = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите количество минут: ");
                    Stopwatch.Minutes = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите количество секунд: ");
                    Stopwatch.Seconds = Convert.ToInt32(Console.ReadLine());
                    Stopwatch.TimeSetted = true;
                    Stopwatch.TimeSettered = new int[] {Stopwatch.Hours, Stopwatch.Minutes, Stopwatch.Seconds};
                    break;
            }
            ThreadPrinter.Resume();
            Menu.Start();
        }


    }
}
