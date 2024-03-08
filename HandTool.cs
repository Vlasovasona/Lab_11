using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_10
{
    public class HandTool : Instrument, IInit                      //класс internal, потому что он доступен только в этой сборке
    {                                                     //класс public, потому что нужно, чтобы работали тесты
        private string material;
        public static int count;

        static string[] materials = { "Дерево", "Сталь", "Пластик", "Железо" };

        protected string Material { get; set; }

        public HandTool() : base()
        {
            Material = "Нет материала";
            count ++;
        }

        public HandTool(int id, string name, string material) : base(name, id)
        {
            Material = material;
            count++;
        }

        public override void Show()
        {
            Console.WriteLine($"{id}: Ручной инструмент. Название: {Name}, материал: {Material}");
        }

        public void ShowUsual()                                        //скортыие имен
        {
            Console.WriteLine($"Название: {Name} Материал: {Material}");
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите материал ручного инструмента");
            Material = Console.ReadLine();
        }

        public override void RandomInit()
        {
            base.RandomInit();
            Material = materials[rnd.Next(materials.Length)];
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is HandTool instr)
            {
                return instr.Name == this.Name && instr.id.number == this.id.number && instr.Material == this.Material;
            }
            else return false;
        }
    }
}
