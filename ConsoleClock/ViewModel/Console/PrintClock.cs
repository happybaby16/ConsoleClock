using System;
using ConsoleClock.Model;
using ConsoleClock.Interface;

namespace ConsoleClock.ViewModel
{
    static class PrintClock
    {
        public static void Print(IPrinter ObjectPrint)
        {
            string Hours, Minutes, Seconds;
            Hours = Convert.ToString(ObjectPrint.Hours);
            Minutes = Convert.ToString(ObjectPrint.Minutes);
            Seconds = Convert.ToString(ObjectPrint.Seconds);
            if (ObjectPrint.Hours < 10) Hours = "0" + ObjectPrint.Hours;
            if (ObjectPrint.Minutes < 10) Minutes = "0" + ObjectPrint.Minutes;
            if (ObjectPrint.Seconds < 10) Seconds = "0" + ObjectPrint.Seconds;
            Console.WriteLine($"{Hours}:{Minutes}:{Seconds}");
            Preview(ObjectPrint);
        }

        public static void Preview(IPrinter ObjectPrint)
        {
            switch (ObjectPrint.Preview)
            {
                case 0: //Превью часов
                    Console.WriteLine("Нажмите на клавишу для действия:\n" +
                                      "1 - Поставить на паузу\n" +
                                      "2 - Снять с паузы\n" +
                                      "3 - Режим секундомера\n" +
                                      "4 - Режим таймера\n" +
                                      "5 - Назначить время\n" +
                                      "Действие: ");
                    break;
                case 1://Превью секундомера
                    Console.WriteLine("Нажмите на клавишу для действия:\n" +
                                      "1 - Поставить на паузу\n" +
                                      "2 - Снять с паузы\n" +
                                      "3 - Обновить таймер\n" +
                                      "0 - Выйти из режима секундомера\n" +
                                      "Действие: ");
                    break;
                case 2://Превью таймера
                    Console.WriteLine("Нажмите на клавишу для действия:\n" +
                                      "1 - Поставить на паузу\n" +
                                      "2 - Снять с паузы\n" +
                                      "3 - Обновить таймер (начать сначала)\n" +
                                      "0 - Выйти из режима таймера\n" +
                                      "Действие: ");
                    break;
            }
        }
        public static void Clear()
        {
            Console.Clear();
        }
    }

   
}
