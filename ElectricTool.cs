using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_10
{
    public class ElectricTool : Instrument, IInit
    {
        private string powerSupply;
        public int workingTime;
        public static int count;

        static string[] supply = { "Электричество" };
        static int[] hours = { 0, 30, 60, 120, 240, 180 };

        protected string PowerSupply { get; set; }
        protected int WorkingTime
        {
            get => workingTime;
            set
            {
                if (value < 0)
                    throw new Exception("Время работы от аккумулятора не может быть отрицательным");
                else workingTime = value;
            }
        }

        public ElectricTool() : base()                          //конструкторы
        {
            PowerSupply = "Нет источника питания";
            WorkingTime = 0;
            count++;
        }


        public ElectricTool(int id, string name, string powerSupply, int workingTime) : base(name, id)
        {
            PowerSupply = powerSupply;
            WorkingTime = workingTime;
            count++;
        }

        public override void Show()                                  //сокрытие имен
        {
            Console.WriteLine($"{id}: Электрический инструмент. Название: {Name}, источник питания: {PowerSupply}, время работы от аккумулятора: {WorkingTime}");
        }

        public void ShowUsual()
        {
            Console.WriteLine($"Название: {Name}  Единицы измерения: {PowerSupply}, время работы от аккумулятора: {WorkingTime}");
        }

        public override void Init()
        {
            base.Init();
            Console.WriteLine("Источник питания электрического инструмента");
            PowerSupply = Console.ReadLine();
            Console.WriteLine("Введите время работы инструмента от аккумулятора в минутах. Если аккумулятора нет, введите 0");
            try
            {
                WorkingTime = int.Parse(Console.ReadLine());
            }
            catch
            {
                WorkingTime = 0;
            }
        }

        public override void RandomInit()
        {
            base.RandomInit();
            PowerSupply = supply[rnd.Next(supply.Length)];
            WorkingTime = hours[rnd.Next(hours.Length)];
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is ElectricTool instr)
            {
                return instr.Name == this.Name && instr.id.number == this.id.number && instr.PowerSupply == this.PowerSupply && instr.WorkingTime == this.WorkingTime;
            }
            else return false;
        }
    }
}
