using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание №3 из книги Абрамов С.А., Гнездилова Г.Г., Капустина Е.Н., Селюн М.И. Задачи по программированию. М.: Наука, 1988.\n 59в \n Проверить точку на принадлежность области");
            Console.WriteLine("Введите координату Х:");
            double x = TakeNumber();
            Console.WriteLine("Введите координату У:");
            double y = TakeNumber();
            bool answer;
            answer = (x >= 0)&&((x * x) + (y * y) - 1 <= 0)||(Math.Abs(y) - 1 - x / 2 <= 0);
                if (answer)
                Console.WriteLine("Ваша точка принадлежит заданной области");
            else Console.WriteLine("Ваша точка не принадлежит заданной области");
            Console.WriteLine("Нажмите Enter...");
            Console.ReadLine();
        }

        static double TakeNumber()
        {
            double n = 0;
            bool ok = true;
            do
            {
                ok = double.TryParse(Console.ReadLine(), out n);
                if (!ok) Console.WriteLine("Не вверный ввод данных. Введите еще раз: ");
            } while (!ok);
            return n;
        }

    }
}
