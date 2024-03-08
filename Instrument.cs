﻿namespace Library_10
{
    public class IdNumber
    {
        public int number;
        public int Number
        {
            get => number;
            set
            {
                if (value < 0)
                    throw new Exception("id не может быть отрицательным");
                else number = value;
            }
        }
        public IdNumber(int number)
        {
            Number = number;
        }
        public override string ToString()
        {
            return number.ToString();
        }
        public override bool Equals(object? obj)
        {
            if (obj is IdNumber n)
                return this.number == n.number;
            return false;
        }
    }

    public class Instrument: IInit, IComparable, ICloneable
    {
        public string name;
        public static int count;
        public IdNumber id;

        protected Random rnd = new Random();

        static string[] Names = { "Отвертка", "Молоток", "Пила", "Ключ", "Дрель", "Шлифовальная машина", "Перфоратор", "Линейка", "Штангенциркуль", "Углометр", "Микрометр", "Лобзик", "Разводной ключ", "Ножницы", "Болгарка", "Рубанок", "Топопр", "Плоскогубцы", "Рулетка", "Динамометр","Кусачки", "Утики" };

        public string Name { get; set; }

        public Instrument()                     //конструктор без параметров, по умолчанию инструмент отвертка
        {
            Name = "Нет инструмента";
            id = new IdNumber(1);
            count++;
        }
        public Instrument(string name, int number)          //конструктор с параметром
        {
            Name = name;
            id = new IdNumber(number);
            count++;
        }
        //механизм позднего связывания. для каждого класса строится таблица виртуальных методов, там хранится адрес Show. Во время создания объекта
        //в таблицу записывается его адрес. Когда перебираем массив, сначала переходим на объект, а потом в нужную таблицу ВМ и найдем адрес метода Show
        public virtual void Show()                      //виртуальный метод для просмотра, он проверяет на какой объект ссылка типа Instrument ссылается
        {
            Console.WriteLine($"{id}: {Name}");
        }

        public void ShowUsual()
        {
            Console.WriteLine($"Название инструмента: {Name}");
        }

        public virtual void Init()
        {
            try
            {
                id.number = int.Parse(Console.ReadLine());
            }
            catch
            {
                id.number = 0;
            }
            Console.WriteLine("Введите имя");
            Name = Console.ReadLine();
        }

        public virtual void RandomInit()
        {
            Name = Names[rnd.Next(Names.Length)];
            id.number = rnd.Next(1, 100);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is Instrument instr)
            {
                return instr.Name == this.Name && instr.id.number == this.id.number;
            }
            else return false;
        }

        public static int CountOutput()
        {
            return count;
        }

        public int CompareTo(object? obj)
        {
            if (obj == null)
                return -1;
            if (obj is not Instrument) return -1;
            Instrument inst = obj as Instrument;
            return String.Compare(this.Name, inst.Name);
        }

        public object Clone()
        {
            return new Instrument(Name, id.number);
        }

        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
    }
}
