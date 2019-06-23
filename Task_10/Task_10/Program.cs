using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10
{
    class Program
    {
        static void Sequence(List<double> a)
        {
            bool flag = true;
            for (int i = 1; i < a.Count; i++)
            {
                if (a[i - 1] >= a[i])
                {
                    flag = false;
                    break;
                }
            }
            if (a.Count == 0)
                Console.WriteLine($"Последовательность пуста ");
            else
            {
                if (!flag)
                {
                    Console.WriteLine($"Производится перестановка...  ");
                    a.Reverse();
                }
                Console.WriteLine($"\nРезультирующая последовательность :{string.Join(" ", a)}");
            }


        }

        static double Check(int max = 10000)
        {
            double to = 0;
            bool flag = true;
            bool ok;

            while (flag)
            {
                do
                {
                    string from = Console.ReadLine();
                    ok = Double.TryParse(from, out to);
                    if (!ok)
                        Console.WriteLine("Ошибка! Действительное число введено неверно. Повторите ввод.");
                    if (to > max)
                    {
                        flag = true;
                        Console.WriteLine("Ошибка! Число больше заданного диапазона. Повторите ввод.");
                    }
                } while ((!ok) || (to > max));
                flag = false;
            }
            return to;
        }

            static void Main(string[] args)
        {
            Console.WriteLine("Задание №10 из книги Абрамов С.А., Гнездилова Г.Г., Капустина Е.Н., Селюн М.И. Задачи по программированию. М.: Наука, 1988.\n 532 \n Если последовательность a_1,...,a_n упорядочена по неубыванию, то оставить ее без изменения. Иначе перевернуть последовательность ");
            Console.WriteLine("Введите количество элементов");
            int n = InputNatNumber();
            List<double> a = new List<double>();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите действительное число");
                a.Add(Check());
            }
            Sequence(a);
            Console.WriteLine("\nДля выхода нажмите клавишу Enter...");
            Console.ReadKey();
        }
        
        //Проверка введенного числа, натуральное ли оно
        public static int InputNatNumber()
        {
            bool ok;
            int n;
            do
            {
                string buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out n);
                if ((!ok) || (n <= 0))
                    Console.WriteLine("Натуральное число введено неверно. Повторите ввод.");
            } while ((!ok) || (n <= 0));
            return n;
        }
    }
}
    

