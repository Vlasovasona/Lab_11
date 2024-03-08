using ConsoleApp2;
using Лабораторная_работа_11;
using System.Collections;
using System.Diagnostics.Metrics;
using Library_10;
using System.Collections.Generic;
namespace Лаба_10
{
    internal class Program
    {
        static sbyte InputSbyteNumber(string msg = "Введиче число")
        {
            Console.WriteLine(msg);
            bool isConvert;
            sbyte number;
            do
            {
                isConvert = sbyte.TryParse(Console.ReadLine(), out number);
                if (!isConvert) Console.WriteLine("Неправильно введено число. Возможно вы ввели слишком длинное число. Попробуйте заново");
            } while (!isConvert);
            return number;
        }

        //ЗАПРОСЫ ДЛЯ ПЕРВОЙ ЧАСТИ НАЧАЛО

        static int CountMeasuring(SortedList list)               //количество измерительных инструментов массива
        {
            int count = 0;
            IList values = list.GetValueList();
            foreach (Library_10.Instrument meas in values)
            {
                if (meas is MeasuringTool)
                {
                    count++;
                }
            }
            return count;
        }

        static int CountOfHandTools(SortedList list)                             //вывести количество ручных инструментов массива (typeof)
        {
            int count = 0;
            IList values = list.GetValueList();
            Type t = typeof(HandTool);                                             //объект типа type содержит информацию о заданном типе
            foreach (Library_10.Instrument inst in values)
            {
                if (t == inst.GetType())
                    count++;
            }
            return count;
        }

        static double MeasuringMiddleValue(SortedList list)        //метод, вычисляющий среднюю точность изм. инструментов (as)
        {
            double middleValue = 0;
            int count = 0;
            IList values = list.GetValueList();
            foreach (Library_10.Instrument inst in values)
            {
                MeasuringTool measTool = inst as MeasuringTool;                    
                if (measTool != null)
                {
                    middleValue += measTool.accuracy;
                    count++;
                }
            }
            if (count > 0)
                return middleValue / count;
            else return -1;
        }

        //ЗАПРОСЫ ДЛЯ ПЕРВОЙ ЧАСТИ КОНЕЦ

        //ХАПРОСЫ ДЛЯ ВТОРОЙ ЧАСТИ НАЧАЛО

        static int CountMeasuringType(List<Library_10.Instrument> list)               //количество измерительных инструментов массива list
        {
            int count = 0;
            foreach (Library_10.Instrument meas in list)
            {
                if (meas is MeasuringTool)
                {
                    count++;
                }
            }
            return count;
        }

        static int CountOfHandToolsType(List<Library_10.Instrument> list)                             //вывести количество ручных инструментов массива (typeof) list
        {
            int count = 0;
            Type t = typeof(HandTool);                                            
            foreach (Library_10.Instrument inst in list)
            {
                if (t == inst.GetType())
                    count++;
            }
            return count;
        }

        static double MeasuringMiddleValueType(List<Library_10.Instrument> list)        //метод, вычисляющий среднюю точность изм. инструментов (as) list
        {
            double middleValue = 0;
            int count = 0;
            foreach (Library_10.Instrument inst in list)
            {
                MeasuringTool measTool = inst as MeasuringTool;
                if (measTool != null)
                {
                    middleValue += measTool.accuracy;
                    count++;
                }
            }
            if (count > 0)
                return middleValue / count;
            else return -1;
        }

        //ЗАПРОСЫ ДЛЯ ВТОРОЙ ЧАСТИ КОНЕЦ

        //ПЕЧАТЬ И СОЗДАНИЕ КОЛЛЕКЦИЙ

        static SortedList CloneUniversalCollection(SortedList list)       //метод для клонирования универсальной коллекции
        {
            SortedList clone = new SortedList();
            int key = 0;
            IList values = list.GetValueList();
            foreach (Library_10.Instrument inst in values)
            {
                if (inst is ICloneable)
                    clone.Add(key, ((ICloneable)inst).Clone());
                key++;
            }
            return clone;
        }

        static List<Library_10.Instrument> CloneTypeList(List<Library_10.Instrument> list)
        {
            List<Library_10.Instrument> clone = new List<Library_10.Instrument>(list.Count);
            foreach (Library_10.Instrument item in list)
            {
                if (item is ICloneable)
                    clone.Add((Library_10.Instrument)((ICloneable)item).Clone());
            }
            return clone;
        }

        static SortedList CreateUniversalCollection()                   //метод для создания универсальной коллекции
        {
            //формирование коллекции, заполнение массива
            SortedList list = new SortedList();               //создаем и заполняем коллекцию
            for (int i = 0; i < 2; i++)
            {
                Library_10.Instrument tool = new Library_10.Instrument();
                tool.RandomInit();
                list.Add(i, tool);                        
            }
            for (int j = 2; j < 5; j++)
            {
                MeasuringTool tool2 = new MeasuringTool();
                tool2.RandomInit();
                list.Add(j, tool2);
            }
            for (int k = 5; k < 8; k++)
            {
                HandTool tool3 = new HandTool();
                tool3.RandomInit();
                list.Add(k, tool3);
            }
            return list;
        }

        static List<Library_10.Instrument> CreateListCollection()                       //метод для создания обобщенной коллекции
        {
            //формирование коллекции, заполнение массива
            List<Library_10.Instrument> list = new List<Library_10.Instrument>();               //создаем и заполняем коллекцию
            for (int i = 0; i < 2; i++)
            {
                Library_10.Instrument tool = new Library_10.Instrument();
                tool.RandomInit();
                list.Add(tool);
            }
            for (int j = 2; j < 5; j++)
            {
                MeasuringTool tool2 = new MeasuringTool();
                tool2.RandomInit();
                list.Add(tool2);
            }
            for (int k = 5; k < 8; k++)
            {
                HandTool tool3 = new HandTool();
                tool3.RandomInit();
                list.Add(tool3);
            }
            return list;
        }

        static void ShowMas(SortedList list)                            //метод для печати универсальной коллекции
        {
            if (list == null)
                Console.WriteLine("Массив пуст");
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine("\t{0}:\t{1}", list.GetKey(i),list.GetByIndex(i));
                }
            }
        }

        static void ShowTypeList(List<Library_10.Instrument> list)              //метод для печати обобщенной коллекции
        {
            if (list == null)
                Console.WriteLine("Массив пуст");
            else
            {
                foreach (Library_10.Instrument item in list)
                    Console.WriteLine(item.ToString());
            }
        }

        static void Main(string[] args)
        {

            sbyte answer3, answerGlobal, answer1, answer2;
            do
            {
                Console.WriteLine("1. Первая часть");
                Console.WriteLine("2. Вторая часть");
                Console.WriteLine("3. Третья часть");
                Console.WriteLine("4. Выйти");

                answerGlobal = InputSbyteNumber("Выберите, какую часть работы вы хотите посмотреть");

                switch (answerGlobal)
                {
                    case 1:         //первая часть.Начало
                        {
                            SortedList list = CreateUniversalCollection();               //предварительно формируем универсальную коллекцию
                            do
                            {

                                Console.WriteLine("1. Сформировать массив, ввести элемент для поиска, отсортировать и вывести полученное на экран");
                                Console.WriteLine("2. Показать count и capacity");
                                Console.WriteLine("3. Поиск и удаление");
                                Console.WriteLine("4. Запросы");
                                Console.WriteLine("5. Клонированиеt");
                                Console.WriteLine("6. Выход");
                                answer1 = InputSbyteNumber();

                                switch (answer1)
                                {
                                    case 1:  //вводим элемент для поиска, добавляем его в массив, проводим сортировку
                                        {
                                            //создаем элемент, добавим его в массив
                                            ShowMas(list);
                                            Console.WriteLine("Введите элемент типа Instrument, который хотите добавить в конец массива");
                                            Library_10.Instrument toolAdd = new Library_10.Instrument();
                                            toolAdd.Init();
                                            list.Add(list.Count, toolAdd);
                                            //печать массива
                                            ShowMas(list);
                                            Console.WriteLine();
                                            break;
                                        }
                                    case 2: //Count и Capacity
                                        {
                                            Console.WriteLine($"Емкость = {list.Capacity}");
                                            Console.WriteLine($"Количество элементов = {list.Count}");
                                            Console.WriteLine();
                                            break;
                                        }
                                    case 3: //поиск и удаление эелмента 
                                        {
                                            if (list.Count == 0)
                                            {
                                                Console.WriteLine("Массив пуст. Операция удаления невозможна.");
                                            }
                                            else
                                            {
                                                Library_10.Instrument toolSearch = new Library_10.Instrument();
                                                Console.WriteLine("Введите id и название элемента типа Instrument, который вы хотите найти в массиве и удалить");
                                                toolSearch.Init();
                                                int position = list.IndexOfValue(toolSearch);
                                                if (position >= 0)
                                                {
                                                    Console.WriteLine($"Элемент находится на {position + 1} позиции. Удаляем элемент из массива");
                                                    list.RemoveAt(position);
                                                }
                                                if (list.ContainsValue(toolSearch))
                                                    Console.WriteLine("Найден");
                                                else
                                                    Console.WriteLine("Не найден");
                                                //выводим измененный массив
                                                ShowMas(list);
                                                Console.WriteLine();
                                            }
                                            break;
                                        }
                                    case 4: //запросы
                                        {
                                            Console.WriteLine($"Количество измерительных инструментов в массиве: {CountMeasuring(list)}");
                                            if (MeasuringMiddleValue(list) >= 0)
                                                Console.WriteLine($"Средняя точность измерительных интсрументов массива равна {MeasuringMiddleValue(list)}");
                                            else
                                                Console.WriteLine("Измерительные инструменты не найдены в массиве");
                                            Console.WriteLine($"Количество ручных инструментов в массиве: {CountOfHandTools(list)}");
                                            Console.WriteLine();
                                            break;
                                        }
                                    case 5: //клонирование колллекции
                                        {
                                            SortedList cloneMas = CloneUniversalCollection(list);
                                            ShowMas(cloneMas);
                                            break;
                                        }
                                    case 6: //выход из кейса
                                        {
                                            Console.WriteLine("Демонстрация завершена");
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("Неправильно задан пункт меню");
                                            break;
                                        }
                                }

                            } while (answer1 != 6);
                            break;
                        } //первая часть закончена
                    case 2: //вторая часть лабораторной
                        {
                            List<Library_10.Instrument> list2 = CreateListCollection();
                            do
                            {
                                Console.WriteLine("1. Сформировать массив, ввести элемент для поиска, отсортировать и вывести полученное на экран");
                                Console.WriteLine("2. Показать count и capacity");
                                Console.WriteLine("3. Поиск и удаление");
                                Console.WriteLine("4. Запросы");
                                Console.WriteLine("5. Клонирование");
                                Console.WriteLine("6. Выход");
                                answer2 = InputSbyteNumber();

                                switch (answer2)
                                {
                                    case 1:  //демонстрируем IInit
                                        {
                                            //создаем элемент для поиска, добавим его в массив
                                            ShowTypeList(list2);
                                            Console.WriteLine("Введите элемент, который хотите добавить в массив");
                                            Library_10.Instrument toolAdd = new Library_10.Instrument();
                                            toolAdd.Init();
                                            list2.Add(toolAdd);
                                            //list.Sort();
                                            //печать массива
                                            ShowTypeList(list2);
                                            Console.WriteLine();
                                            break;
                                        }
                                    case 2: //count capacity
                                        {
                                            Console.WriteLine($"Емкость = {list2.Capacity}");
                                            Console.WriteLine($"Количество элементов = {list2.Count}");
                                            Console.WriteLine();
                                            break;
                                        }
                                    case 3: //поиск и удаление
                                        {
                                            Library_10.Instrument toolSearch = new Library_10.Instrument();
                                            Console.WriteLine("Введите id и название инструмента, который вы хотите найти в массиве и удалить");
                                            toolSearch.Init();

                                            if (list2.Contains(toolSearch))
                                                Console.WriteLine("Найден");
                                            else
                                                Console.WriteLine("Не найден");
                                            int position = list2.IndexOf(toolSearch);
                                            if (position >= 0)
                                            {
                                                Console.WriteLine($"Элемент находится на {position + 1} позиции. Удаляем элемент из массива");
                                                list2.RemoveAt(position);
                                            }
                                            //выводим измененный массив (прежде отсортируем его)
                                            list2.Sort();
                                            ShowTypeList(list2);
                                            Console.WriteLine();
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.WriteLine($"Количество измерительных инструментов в массиве: {CountMeasuringType(list2)}");
                                            if (MeasuringMiddleValueType(list2) >= 0)
                                                Console.WriteLine($"Средняя точность измерительных интсрументов массива равна {MeasuringMiddleValueType(list2)}");
                                            else
                                                Console.WriteLine("Измерительные инструменты не найдены в массиве");
                                            Console.WriteLine($"Количество ручных инструментов в массиве: {CountOfHandToolsType(list2)}");
                                            Console.WriteLine();
                                            break;
                                        }
                                    case 5:
                                        {
                                            List<Library_10.Instrument> clone = CloneTypeList(list2);
                                            ShowTypeList(clone);
                                            break;
                                        }
                                    case 6: //выход из кейса
                                        {
                                            Console.WriteLine("Демонстрация завершена");
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("Неправильно задан пункт меню");
                                            break;
                                        }
                                }

                            } while (answer2 != 5);
                            break;
                        } //демонстрация второй части лабораторной работы окончена
                    case 3: //третья часть лабораторной работы
                        {
                            do
                            {

                                Console.WriteLine("1. Показать время поиска элементов");
                                Console.WriteLine("2. Выход");
                                answer3 = InputSbyteNumber();

                                switch (answer3)
                                {
                                    case 1:
                                        {
                                            TestColllection test = new Лабораторная_работа_11.TestColllection();
                                            test.Prog();
                                            break;
                                        }
                                    case 2: //выход из кейса
                                        {
                                            Console.WriteLine("Демонстрация завершена");
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("Неправильно задан пункт меню");
                                            break;
                                        }
                                }

                            } while (answer3 != 2);
                            break;
                        }
                }
            } while (answerGlobal != 4);
        }
    }
}
