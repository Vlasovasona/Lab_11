using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_10
{
    public class MeasuringTool : Instrument, IInit
    {
        private string units;
        public double accuracy;
        public static int count;

        static string[] uni = { "Сантиметры", "Миллиметры", "Метры", "Градусы" };
        static double[] acc = { 1, 0.01, 0.1, 0.5, 0.05 };

        protected string Units { get; set; }
        protected double Accuracy
        {
            get => accuracy;
            set
            {
                if (value < 0)
                    throw new Exception("Точность не может быть отрицательной");
                else if (value > 5.0)
                    throw new Exception("Точность не может быть больше 5 мм");
                else accuracy = value;
            }
        }

        public MeasuringTool() : base()                          //конструкторы
        {
            Units = "Нет единиц измерения";
            Accuracy = 0;
            count++;
        }


        public MeasuringTool(int id, string name, string units, int accuracy) : base(name, id)
        {
            Units = units;
            Accuracy = accuracy;
            count++;
        }

        public override void Show()                                  //для сокрытия имен используем new
        {
            Console.WriteLine($"{id}: Измерительный инструмент. Название: {Name}, единицы измерения: {Units}, точность: {Accuracy}");
        }

        public void ShowUsual()
        {
            Console.WriteLine($"Название: {Name} Единицы измерения: {Units}, точность: {Accuracy}");
        }

        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите единицы измерения");
            Units = Console.ReadLine();
            Console.WriteLine("Введите точность измерительного инструмента");
            try
            {
                Accuracy = double.Parse(Console.ReadLine());
            }
            catch
            {
                Accuracy = 0;
            }
        }

        public override void RandomInit()
        {
            base.RandomInit();
            Units = uni[rnd.Next(uni.Length)];
            Accuracy = acc[rnd.Next(acc.Length)];
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is MeasuringTool instr)
            {
                return instr.Name == this.Name && instr.id.number == this.id.number && instr.Accuracy == this.Accuracy && instr.Units == this.Units;
            }
            else return false;
        }

        public static void WoodInstrument(double number, MeasuringTool tool)            //названаие измерительного инструмента, точность которого больше чем number
        {
            if (tool.accuracy < number)
                Console.WriteLine(tool.name);
        }

    }
}
