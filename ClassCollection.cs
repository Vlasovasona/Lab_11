using Library_10;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Лабораторная_работа_11;

namespace Лабораторная_работа_11
{
    internal class TestColllection
    {
        HandTool firstPlace, middlePlace, lastPlace;

        Queue<HandTool> mas1 = new Queue<HandTool>();
        Queue<string> mas2 = new Queue<string>();
        SortedSet<Library_10.Instrument> mas3 = new SortedSet<Library_10.Instrument>();
        SortedSet<string> mas4 = new SortedSet<string>();

        public TestColllection()
        {
            for (int i = 0; i < 1000; i++)
            {
                try
                {
                    HandTool tool = new HandTool();
                    tool.RandomInit();
                    mas1.Enqueue(tool);
                    mas2.Enqueue(tool.ToString());
                    mas3.Add(tool.GetBase);
                    mas4.Add(tool.GetBase.ToString());

                    if (i == 0)
                    {
                        firstPlace = (HandTool)tool.Clone();
                    }
                    if (i == 500)
                    {
                        middlePlace = (HandTool)tool.Clone();
                    }
                    if (i == 999)
                    {
                        lastPlace = (HandTool)tool.Clone();
                    }
                }
                catch
                {
                    i--;
                }
            }
        }
        public void Prog()
        {

            //первое число каждого массива
            Console.WriteLine("Выводим время нахождения первого элемента каждой коллекции:");
            Console.WriteLine("Первая коллекция:");
            Stopwatch sw = Stopwatch.StartNew();
            sw.Restart();
            bool okKey = mas1.Contains(firstPlace);
            sw.Stop();
            if (okKey)
                Console.WriteLine($"Найден за {sw.ElapsedTicks}");
            else Console.WriteLine($"Не найден за {sw.ElapsedTicks}");

            Console.WriteLine("Вторая коллекция:");
            sw.Restart();
            bool okValue = mas2.Contains(firstPlace.ToString());
            sw.Stop();
            if (okValue)
                Console.WriteLine($"Найден за {sw.ElapsedTicks}");
            else Console.WriteLine($"Не найден за {sw.ElapsedTicks}");

            Console.WriteLine("Третья коллекция:");
            sw.Restart();
            bool okKeySet = mas3.Contains(firstPlace);
            sw.Stop();
            if (okKeySet)
                Console.WriteLine($"Найден за {sw.ElapsedTicks}");
            else Console.WriteLine($"Не найден за {sw.ElapsedTicks}");

            Console.WriteLine("Четвертая коллекция:");
            sw.Restart();
            bool okKeySetString = mas4.Contains(firstPlace.GetBase.ToString());
            sw.Stop();
            if (okKeySetString)
                Console.WriteLine($"Найден за {sw.ElapsedTicks}");
            else Console.WriteLine($"Не найден за {sw.ElapsedTicks}");

            //среднее число каждого массива
            Console.WriteLine("Выводим время нахождения среднего элемента каждой коллекции:");
            Console.WriteLine("Первая коллекция:");
            Stopwatch sw2 = Stopwatch.StartNew();

            sw2.Restart();
            bool okKeyMiddle = mas1.Contains(middlePlace);
            sw2.Stop();
            if (okKeyMiddle)
                Console.WriteLine($"Найден за {sw2.ElapsedTicks}");
            else Console.WriteLine($"Не найден за {sw2.ElapsedTicks}");

            Console.WriteLine("Вторая коллекция:");
            sw2.Restart();
            bool okValueMiddle = mas2.Contains(middlePlace.ToString());
            sw2.Stop();
            if (okValueMiddle)
                Console.WriteLine($"Найден за {sw2.ElapsedTicks}");
            else Console.WriteLine($"Не найден за {sw2.ElapsedTicks}");

            Console.WriteLine("Третья коллекция:");
            sw2.Restart();
            bool okKeySetMiddle = mas3.Contains(middlePlace);
            sw2.Stop();
            if (okKeySetMiddle)
                Console.WriteLine($"Найден за {sw2.ElapsedTicks}");
            else Console.WriteLine($"Не найден за {sw2.ElapsedTicks}");

            Console.WriteLine("Четвертая коллекция:");
            sw2.Restart();
            bool okKeySetStringMiddle = mas4.Contains(middlePlace.GetBase.ToString());
            sw2.Stop();
            if (okKeySetStringMiddle)
                Console.WriteLine($"Найден за {sw2.ElapsedTicks}");
            else Console.WriteLine($"Не найден за {sw2.ElapsedTicks}");

            //последнее число каждой коллекции
            Console.WriteLine("Выводим время нахождения последнего элемента каждой коллекции:");
            Console.WriteLine("Первая коллекция:");
            sw.Restart();
            bool okKeyLast = mas1.Contains(lastPlace);
            sw.Stop();
            if (okKeyLast)
                Console.WriteLine($"Найден за {sw.ElapsedTicks}");
            else Console.WriteLine($"Не найден за {sw.ElapsedTicks}");

            Console.WriteLine("Вторая коллекция:");
            sw.Restart();
            bool okValueLast = mas2.Contains(lastPlace.ToString());
            sw.Stop();
            if (okValueLast)
                Console.WriteLine($"Найден за {sw.ElapsedTicks}");
            else Console.WriteLine($"Не найден за {sw.ElapsedTicks}");

            Console.WriteLine("Третья коллекция:");
            sw.Restart();
            bool okKeySetLast = mas3.Contains(lastPlace);
            sw.Stop();
            if (okKeySetLast)
                Console.WriteLine($"Найден за {sw.ElapsedTicks}");
            else Console.WriteLine($"Не найден за {sw.ElapsedTicks}");

            Console.WriteLine("Четвертая коллекция:");
            sw.Restart();
            bool okKeySetStringLast = mas4.Contains(lastPlace.GetBase.ToString());
            sw.Stop();
            if (okKeySetStringLast)
                Console.WriteLine($"Найден за {sw.ElapsedTicks}");
            else Console.WriteLine($"Не найден за {sw.ElapsedTicks}");

            //несуществующий элемент каждой коллекции
            HandTool toolWrong = new HandTool(666, "_ЛОБЗИК_", "Кремень");
            Console.WriteLine("Выводим время нахождения несуществующего элемента каждой коллекции:");
            Console.WriteLine("Первая коллекция:");
            sw.Restart();
            bool okKeyWrong = mas1.Contains(toolWrong);
            sw.Stop();
            if (okKeyWrong)
                Console.WriteLine($"Найден за {sw.ElapsedTicks}");
            else Console.WriteLine($"Не найден за {sw.ElapsedTicks}");

            Console.WriteLine("Вторая коллекция:");
            sw.Restart();
            bool okValueWrong = mas2.Contains(toolWrong.ToString());
            sw.Stop();
            if (okValueWrong)
                Console.WriteLine($"Найден за {sw.ElapsedTicks}");
            else Console.WriteLine($"Не найден за {sw.ElapsedTicks}");

            Console.WriteLine("Третья коллекция:");
            sw.Restart();
            bool okKeySetWrong= mas3.Contains(toolWrong);
            sw.Stop();
            if (okKeySetWrong)
                Console.WriteLine($"Найден за {sw.ElapsedTicks}");
            else Console.WriteLine($"Не найден за {sw.ElapsedTicks}");

            Console.WriteLine("Четвертая коллекция:");
            sw.Restart();
            bool okKeySetStringWrong = mas4.Contains(toolWrong.GetBase.ToString());
            sw.Stop();
            if (okKeySetStringWrong)
                Console.WriteLine($"Найден за {sw.ElapsedTicks}");
            else Console.WriteLine($"Не найден за {sw.ElapsedTicks}");
        }

    }
}



