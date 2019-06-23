using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    class Program
    {
        static void Pifagor(int x)
        {
            for (int digit = 2; digit < x; digit++)
            {
                for (int i = 1; i < x; i++)
                {
                    for (int j = 1; j < x; j++)
                    {
                        if (digit == i * i + j * j)
                        {
                            Console.WriteLine($"{digit} = {i}^2 + {j}^2");
                            digit++;
                        }
                    }
                }
            }
        }

        //Проверка введенного числа
        static int Check(int max = 10000)
        {
            int to = 0;
            bool flag = true;
            bool ok;

            while (flag)
            {
                do
                {
                    string from = Console.ReadLine();
                    ok = Int32.TryParse(from, out to);
                    if ((!ok) || (to <= 0))
                        Console.WriteLine("Ошибка! Натуральное число введено неверно. Повторите ввод.");
                    if (to > max)
                    {
                        flag = true;
                        Console.WriteLine("Ошибка! Число больше заданного диапазона. Повторите ввод.");
                    }
                } while ((!ok) || (to <= 0) || (to > max));
                flag = false;
            }
            return to;

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Задание №3 из книги Абрамов С.А., Гнездилова Г.Г., Капустина Е.Н., Селюн М.И. Задачи по программированию. М.: Наука, 1988.\n 441 \n Найти все числа, которые можно представить в виде суммы квадратов двух натуральных чисел");
            Console.WriteLine("Введите число N и нажмите клавишу Enter");
            Pifagor((int)Check());
            Console.WriteLine("\nДля выхода нажмите клавишу Enter...");
            Console.ReadKey();
        }
    }
}
